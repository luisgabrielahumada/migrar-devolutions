using System;
using System.Collections.Generic;
using System.Web.Http.Description;
using Swashbuckle.Swagger;

namespace Asesoftware.Sodimac.BackHc.ApiRest.App_Start
{
	// Token: 0x02000007 RID: 7
	public class AddRequiredHeaderParameter : IOperationFilter
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000023A4 File Offset: 0x000005A4
		public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
		{
			if (operation.parameters == null)
			{
				operation.parameters = new List<Parameter>();
			}
			operation.parameters.Add(new Parameter
			{
				name = "api-key",
				@in = "header",
				type = "string",
				required = new bool?(false)
			});
		}
	}
}
