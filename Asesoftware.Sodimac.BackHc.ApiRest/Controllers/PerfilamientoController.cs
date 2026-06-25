using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asesoftware.Sodimac.BackHc.DTO.Mensaje;
using Asesoftware.Sodimac.BackHc.DTO.Perfilamiento;
using Asesoftware.Sodimac.BackHc.Perfilamientos;
using Asesoftware.Sodimac.BackHc.Token;
using Asesoftware.Sodimac.BackHc.Utilidades.Excepciones;

namespace Asesoftware.Sodimac.BackHc.ApiRest.Controllers
{
	// Token: 0x02000006 RID: 6
	[ApiController]
	[Route("perfilamiento")]
	public class PerfilamientoController : ControllerBase
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000022C8 File Offset: 0x000004C8
		[HttpPut]
		[Route("actualizar")]
		public async Task<IActionResult> ActualizarPerfilamientoAsync([FromBody] PerfilamientoDTO perfilamiento)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return StatusCode((int)HttpStatusCode.BadRequest, new Mensaje
					{
						codigoRespuesta = "1",
						mensajeRespuesta = "El json no es valido.",
						objetoRespuesta = ModelState
					});
				}
				var re = Request;
				this._validatoken = new TokenValidacion();
				if (!await this._validatoken.ValidarAsync(re))
				{
					throw new Exception("Token invalido.");
				}
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.Unauthorized, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Token invalido.",
					objetoRespuesta = ex
				});
			}
			IActionResult httpActionResult;
			try
			{
				this.perfilamientoNegocio = new PerfilamientoNegocio();
				this.perfilamientoNegocio.ActualizarPerfilamiento(perfilamiento);
				httpActionResult = StatusCode((int)HttpStatusCode.OK, new Mensaje
				{
					codigoRespuesta = "0",
					mensajeRespuesta = "Actualización realizada satisfactoriamente."
				});
			}
			catch (Exception ex2)
			{
				httpActionResult = StatusCode((int)HttpStatusCode.InternalServerError, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Fallo en consulta.",
					objetoRespuesta = new Exception(ex2.Message, ex2.InnerException)
				});
			}
			return httpActionResult;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002318 File Offset: 0x00000518
		[HttpGet]
		[Route("consultar")]
				public async Task<IActionResult> ConsultarPerfilamientoAsync(string email = "")
		{
			try
			{
				var re = Request;
				this._validatoken = new TokenValidacion();
				if (!await this._validatoken.ValidarAsync(re))
				{
					throw new Exception("Token invalido.");
				}
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.Unauthorized, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Token invalido.",
					objetoRespuesta = ex
				});
			}
			IActionResult httpActionResult;
			try
			{
				if (string.IsNullOrEmpty(email))
				{
					httpActionResult = StatusCode((int)HttpStatusCode.BadRequest, new Mensaje
					{
						codigoRespuesta = "1",
						mensajeRespuesta = "Falta uno o más parámetros para realizar la consulta."
					});
				}
				else
				{
					this.perfilamientoNegocio = new PerfilamientoNegocio();
					httpActionResult = StatusCode((int)HttpStatusCode.OK, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "",
						objetoRespuesta = this.perfilamientoNegocio.ConsultarPerfilamiento(email)
					});
				}
			}
			catch (ExcepcionOperacion exOp)
			{
				httpActionResult = StatusCode((int)HttpStatusCode.InternalServerError, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Fallo en consulta.",
					objetoRespuesta = new Exception(exOp.Message, exOp.InnerException)
				});
			}
			catch (Exception ex2)
			{
				httpActionResult = StatusCode((int)HttpStatusCode.InternalServerError, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Fallo en consulta.",
					objetoRespuesta = new Exception(ex2.Message, ex2.InnerException)
				});
			}
			return httpActionResult;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002368 File Offset: 0x00000568
		[NonAction]
		public IList<ValidationResult> myValidation(object model)
		{
			List<ValidationResult> result = new List<ValidationResult>();
			ValidationContext validationContext = new ValidationContext(model);
			Validator.TryValidateObject(model, validationContext, result);
			if (model is IValidatableObject)
			{
				(model as IValidatableObject).Validate(validationContext);
			}
			return result;
		}

		// Token: 0x04000003 RID: 3
		private TokenValidacion _validatoken;

		// Token: 0x04000004 RID: 4
		private PerfilamientoNegocio perfilamientoNegocio;
	}
}
