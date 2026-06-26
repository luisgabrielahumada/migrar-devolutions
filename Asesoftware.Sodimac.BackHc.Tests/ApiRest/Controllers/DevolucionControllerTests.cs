using System.Net;
using Asesoftware.Sodimac.BackHc.ApiRest.Controllers;
using Asesoftware.Sodimac.BackHc.DTO.Devolucion;
using Asesoftware.Sodimac.BackHc.DTO.Mensaje;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Asesoftware.Sodimac.BackHc.Tests.ApiRest.Controllers;

public class DevolucionControllerTests
{
    [Fact]
    public async Task CrearDevolucionesAsync_WhenRequestHasNoApiKey_ReturnsUnauthorizedMessage()
    {
        var controller = CreateController();

        var result = await controller.CrearDevolucionesAsync(new SolicitudDTO());

        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.Unauthorized, objectResult.StatusCode);

        var message = Assert.IsType<Mensaje>(objectResult.Value);
        Assert.Equal("1", message.codigoRespuesta);
        Assert.Equal("Token invalido.", message.mensajeRespuesta);
    }

    [Fact]
    public async Task ConsultarCantidadDevolucionesAsync_WhenRequestHasNoApiKey_ReturnsUnauthorizedMessage()
    {
        var controller = CreateController();

        var result = await controller.ConsultarCantidadDevolucionesAsync("123", "CC");

        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal((int)HttpStatusCode.Unauthorized, objectResult.StatusCode);

        var message = Assert.IsType<Mensaje>(objectResult.Value);
        Assert.Equal("1", message.codigoRespuesta);
        Assert.Equal("Token invalido.", message.mensajeRespuesta);
    }

    private static DevolucionController CreateController()
    {
        return new DevolucionController
        {
            ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            }
        };
    }
}
