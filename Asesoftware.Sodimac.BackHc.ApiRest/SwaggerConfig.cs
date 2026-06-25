using System;
using System.Reflection;
using System.Web.Http;
using Asesoftware.Sodimac.BackHc.ApiRest.App_Start;
using Swashbuckle.Application;

namespace Asesoftware.Sodimac.BackHc.ApiRest
{
	// Token: 0x02000002 RID: 2
	public class SwaggerConfig
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Register()
		{
			Assembly assembly = typeof(SwaggerConfig).Assembly;
			GlobalConfiguration.Configuration.EnableSwagger(delegate(SwaggerDocsConfig c)
			{
				c.SingleApiVersion("v1", "AppHC.ApiRest");
				c.ApiKey("api-key").Description("JWT con token").Name("api-key")
					.In("header");
				c.IncludeXmlComments(SwaggerConfig.GetXmlCommentsPath());
				c.OperationFilter<AddRequiredHeaderParameter>();
			}).EnableSwaggerUi(delegate(SwaggerUiConfig c)
			{
			});
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020BA File Offset: 0x000002BA
		private static string GetXmlCommentsPath()
		{
			return string.Format("{0}\\Documentation\\Asesoftware.Sodimac.BackHc.ApiRest.xml", AppDomain.CurrentDomain.BaseDirectory);
		}
	}
}
