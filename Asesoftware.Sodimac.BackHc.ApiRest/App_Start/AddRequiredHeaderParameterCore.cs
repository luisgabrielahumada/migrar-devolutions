using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Asesoftware.Sodimac.BackHc.ApiRest.App_Start
{
    public class AddRequiredHeaderParameterCore : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "api-key",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                },
                Description = "JWT con token"
            });

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "brokerapikey",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                },
                Description = "API key del broker"
            });
        }
    }
}
