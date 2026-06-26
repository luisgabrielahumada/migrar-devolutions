using System.Net;
using Asesoftware.Sodimac.BackHc.ApiRest.Controllers;
using Asesoftware.Sodimac.BackHc.DTO.Mensaje;
using Asesoftware.Sodimac.BackHc.DTO.Perfilamiento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Asesoftware.Sodimac.BackHc.Tests.ApiRest.Controllers;

public class PerfilamientoControllerTests
{
    [Fact]
    public async Task ActualizarPerfilamientoAsync_WhenRequestHasNoApiKey_ReturnsUnauthorizedMessage()
    {
        var controller = CreateController();

        var result = await controller.ActualizarPerfilamientoAsync(new PerfilamientoDTO());

        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.Unauthorized, objectResult.StatusCode);

        var message = Assert.IsType<Mensaje>(objectResult.Value);
        Assert.Equal("1", message.codigoRespuesta);
        Assert.Equal("Token invalido.", message.mensajeRespuesta);
    }

    [Fact]
    public async Task ConsultarPerfilamientoAsync_WhenRequestHasNoApiKey_ReturnsUnauthorizedMessage()
    {
        var controller = CreateController();

        var result = await controller.ConsultarPerfilamientoAsync("user@example.com");

        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.Unauthorized, objectResult.StatusCode);

        var message = Assert.IsType<Mensaje>(objectResult.Value);
        Assert.Equal("1", message.codigoRespuesta);
        Assert.Equal("Token invalido.", message.mensajeRespuesta);
    }

    private static PerfilamientoController CreateController()
    {
        return new PerfilamientoController
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }
}
