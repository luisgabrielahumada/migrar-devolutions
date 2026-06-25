using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Asesoftware.Sodimac.BackHc.Token
{
	public class TokenValidacion
	{
		public bool isBroker(HttpRequest re)
		{
			return re.Headers.ContainsKey("brokerapikey") && re.Headers["brokerapikey"].FirstOrDefault() == ConfigurationManager.AppSettings["brokerapikey"];
		}

		public async Task<bool> ValidarAsync(HttpRequest re)
		{
			if (!re.Headers.ContainsKey("api-key"))
			{
				return false;
			}

			string token = re.Headers["api-key"].FirstOrDefault();
			this.fw = new FirebaseJWTAuth(ConfigurationManager.AppSettings["proyectoFirebase"]);
			return !string.IsNullOrEmpty(await this.fw.Verify(token));
		}

		private FirebaseJWTAuth fw;
	}
}
