using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

// Token: 0x02000002 RID: 2
public class FirebaseJWTAuth
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public FirebaseJWTAuth(string firebaseId)
	{
		this.FirebaseId = firebaseId;
		this.Req = new HttpClient();
		this.Req.BaseAddress = new Uri("https://www.googleapis.com/robot/v1/metadata/");
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002080 File Offset: 0x00000280
	public static long EpochSec()
	{
		return (long)(DateTime.UtcNow - FirebaseJWTAuth.Jan1st1970).TotalSeconds;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020A8 File Offset: 0x000002A8
	public async Task<string> Verify(string token)
	{
		string hashChunk = token;
		hashChunk = hashChunk.Substring(0, hashChunk.LastIndexOf('.'));
		token = token.Replace('-', '+').Replace('_', '/');
		string[] sections = token.Split(new char[] { '.' });
		FirebaseJWTAuth.JwtHeader header = FirebaseJWTAuth.B64Json<FirebaseJWTAuth.JwtHeader>(sections[0]);
		string text;
		if (header.alg != "RS256")
		{
			text = null;
		}
		else
		{
			HttpResponseMessage res = await this.Req.GetAsync("x509/securetoken@system.gserviceaccount.com");
			if (!res.IsSuccessStatusCode)
			{
				throw new Exception(res.ToString());
			}
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(await res.Content.ReadAsStringAsync());
			string keyStr = null;
			dictionary.TryGetValue(header.kid, out keyStr);
			if (keyStr == null)
			{
				text = null;
			}
			else
			{
				using (RSACryptoServiceProvider rsaCrypto = FirebaseJWTAuth.CertFromPem(keyStr))
				{
					using (SHA256 hasher = SHA256.Create())
					{
						byte[] hashed = hasher.ComputeHash(Encoding.UTF8.GetBytes(hashChunk));
						byte[] challenge = FirebaseJWTAuth.SafeB64Decode(sections[2]);
						RSAPKCS1SignatureDeformatter rsapkcs1SignatureDeformatter = new RSAPKCS1SignatureDeformatter(rsaCrypto);
						rsapkcs1SignatureDeformatter.SetHashAlgorithm("SHA256");
						if (!rsapkcs1SignatureDeformatter.VerifySignature(hashed, challenge))
						{
							return null;
						}
					}
				}
				FirebaseJWTAuth.JwtPayload payload = FirebaseJWTAuth.B64Json<FirebaseJWTAuth.JwtPayload>(sections[1]);
				long currentTime = FirebaseJWTAuth.EpochSec();
				if (payload.aud != this.FirebaseId || payload.iss != "https://securetoken.google.com/" + this.FirebaseId || payload.iat >= currentTime || payload.exp <= currentTime)
				{
					text = null;
				}
				else
				{
					text = string.Concat(new string[] { "Sub:", payload.sub, ", name: ", payload.name, ", email: ", payload.email, ", email_verified: ", payload.email_verified, ", picture: ", payload.picture });
				}
			}
		}
		return text;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000020F5 File Offset: 0x000002F5
	private static T B64Json<T>(string encoded)
	{
		return JsonConvert.DeserializeObject<T>(FirebaseJWTAuth.SafeB64DecodeStr(encoded));
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002102 File Offset: 0x00000302
	private static RSACryptoServiceProvider CertFromPem(string pemKey)
	{
		X509Certificate2 x509Certificate = new X509Certificate2();
		x509Certificate.Import(Encoding.UTF8.GetBytes(pemKey));
		return (RSACryptoServiceProvider)x509Certificate.PublicKey.Key;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x0000212C File Offset: 0x0000032C
	private static byte[] SafeB64Decode(string encoded)
	{
		string encodedPad = encoded;
		while (encodedPad.Length % 4 != 0)
		{
			encodedPad += "=";
		}
		return Convert.FromBase64String(encodedPad);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002159 File Offset: 0x00000359
	private static string SafeB64DecodeStr(string encoded)
	{
		return Encoding.UTF8.GetString(FirebaseJWTAuth.SafeB64Decode(encoded));
	}

	// Token: 0x04000001 RID: 1
	public string FirebaseId;

	// Token: 0x04000002 RID: 2
	private static DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	// Token: 0x04000003 RID: 3
	private HttpClient Req;

	// Token: 0x02000004 RID: 4
	private struct JwtHeader
	{
		// Token: 0x04000005 RID: 5
		public string alg;

		// Token: 0x04000006 RID: 6
		public string kid;
	}

	// Token: 0x02000005 RID: 5
	private struct JwtPayload
	{
		// Token: 0x04000007 RID: 7
		public string aud;

		// Token: 0x04000008 RID: 8
		public string email;

		// Token: 0x04000009 RID: 9
		public string email_verified;

		// Token: 0x0400000A RID: 10
		public long exp;

		// Token: 0x0400000B RID: 11
		public long iat;

		// Token: 0x0400000C RID: 12
		public string iss;

		// Token: 0x0400000D RID: 13
		public string name;

		// Token: 0x0400000E RID: 14
		public string picture;

		// Token: 0x0400000F RID: 15
		public string sign_in_provide;

		// Token: 0x04000010 RID: 16
		public string sub;
	}
}
