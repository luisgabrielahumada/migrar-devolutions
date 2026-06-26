using System.Reflection;
using Asesoftware.Sodimac.BackHc.ApiRest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Asesoftware.Sodimac.BackHc.Tests.ApiRest.Controllers;

public class ControllerMetadataTests
{
    [Theory]
    [InlineData(typeof(DevolucionController))]
    [InlineData(typeof(PerfilamientoController))]
    public void MyValidation_IsMarkedAsNonAction(Type controllerType)
    {
        var method = controllerType.GetMethod("myValidation", BindingFlags.Instance | BindingFlags.Public);

        Assert.NotNull(method);
        Assert.NotNull(method!.GetCustomAttribute<NonActionAttribute>());
    }
}
