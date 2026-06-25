using System;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Asesoftware.Sodimac.BackHc.ApiRest
{
	// Token: 0x02000003 RID: 3
	public static class WebApiConfig
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020D8 File Offset: 0x000002D8
		public static void Register(HttpConfiguration config)
		{
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			config.MapHttpAttributeRoutes();
		}
	}
}
