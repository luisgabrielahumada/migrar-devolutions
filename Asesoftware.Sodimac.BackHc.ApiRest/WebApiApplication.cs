using System;
using System.Web;
using System.Web.Http;

namespace Asesoftware.Sodimac.BackHc.ApiRest
{
	// Token: 0x02000004 RID: 4
	public class WebApiApplication : HttpApplication
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020FF File Offset: 0x000002FF
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(new Action<HttpConfiguration>(WebApiConfig.Register));
		}
	}
}
