using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Asesoftware.Sodimac.BackHc.Token
{
	// Token: 0x02000003 RID: 3
	public class TokenValidacion
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002184 File Offset: 0x00000384
		public bool isBroker(HttpRequestMessage re)
		{
			HttpRequestHeaders headers = re.Headers;
			return headers.Contains("brokerapikey") && headers.GetValues("brokerapikey").First<string>().Equals(ConfigurationManager.AppSettings["brokerapikey"]);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021CC File Offset: 0x000003CC
		public async Task<bool> ValidarAsync(HttpRequestMessage re)
		{
			HttpRequestHeaders headers = re.Headers;
			bool flag;
			if (headers.Contains("api-key"))
			{
				string token = headers.GetValues("api-key").First<string>();
				this.fw = new FirebaseJWTAuth(ConfigurationManager.AppSettings["proyectoFirebase"]);
				TaskAwaiter<string> taskAwaiter = this.fw.Verify(token).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<string> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<string>);
				}
				flag = !string.IsNullOrEmpty(taskAwaiter.GetResult());
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x04000004 RID: 4
		private FirebaseJWTAuth fw;
	}
}
