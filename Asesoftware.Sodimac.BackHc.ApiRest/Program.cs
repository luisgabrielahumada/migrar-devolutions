using Asesoftware.Sodimac.BackHc.ApiRest.App_Start;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "AppHC.ApiRest",
        Version = "v1"
    });
    options.OperationFilter<AddRequiredHeaderParameterCore>();
});

System.Configuration.ConfigurationManager.AppSettings.Set("proyectoFirebase", builder.Configuration["proyectoFirebase"]);
System.Configuration.ConfigurationManager.AppSettings.Set("brokerapikey", builder.Configuration["brokerapikey"]);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "AppHC.ApiRest v1");
    options.RoutePrefix = "swagger";
});

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapControllers();
app.Run();
