using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Asesoftware.Sodimac.BackHc.DTO.Mensaje;
using Asesoftware.Sodimac.BackHc.DTO.Perfilamiento;
using Asesoftware.Sodimac.BackHc.Perfilamientos;
using Asesoftware.Sodimac.BackHc.Token;
using Asesoftware.Sodimac.BackHc.Utilidades.Excepciones;

namespace Asesoftware.Sodimac.BackHc.ApiRest.Controllers
{
	// Token: 0x02000006 RID: 6
	[RoutePrefix("perfilamiento")]
	public class PerfilamientoController : ApiController
	{
		// Token: 0x0600000D RID: 13 RVA: 0x000022C8 File Offset: 0x000004C8
		[HttpPut]
		[Route("actualizar")]
		public async Task<IHttpActionResult> ActualizarPerfilamientoAsync([FromBody] PerfilamientoDTO perfilamiento)
		{
			try
			{
				if (!base.ModelState.IsValid)
				{
					return this.Content<Mensaje>(HttpStatusCode.BadRequest, new Mensaje
					{
						codigoRespuesta = "1",
						mensajeRespuesta = "El json no es valido.",
						objetoRespuesta = base.ModelState
					});
				}
				HttpRequestMessage re = base.Request;
				this._validatoken = new TokenValidacion();
				TaskAwaiter<bool> taskAwaiter = this._validatoken.ValidarAsync(re).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (!taskAwaiter.GetResult())
				{
					throw new Exception("Token invalido.");
				}
			}
			catch (Exception ex)
			{
				return this.Content<Mensaje>(HttpStatusCode.Unauthorized, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Token invalido.",
					objetoRespuesta = ex
				});
			}
			IHttpActionResult httpActionResult;
			try
			{
				this.perfilamientoNegocio = new PerfilamientoNegocio();
				this.perfilamientoNegocio.ActualizarPerfilamiento(perfilamiento);
				httpActionResult = this.Content<Mensaje>(HttpStatusCode.OK, new Mensaje
				{
					codigoRespuesta = "0",
					mensajeRespuesta = "Actualización realizada satisfactoriamente."
				});
			}
			catch (Exception ex2)
			{
				httpActionResult = this.Content<Mensaje>(HttpStatusCode.InternalServerError, new Mensaje
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
		[ResponseType(typeof(Mensaje))]
		public async Task<IHttpActionResult> ConsultarPerfilamientoAsync(string email = "")
		{
			try
			{
				HttpRequestMessage re = base.Request;
				this._validatoken = new TokenValidacion();
				TaskAwaiter<bool> taskAwaiter = this._validatoken.ValidarAsync(re).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter<bool> taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (!taskAwaiter.GetResult())
				{
					throw new Exception("Token invalido.");
				}
			}
			catch (Exception ex)
			{
				return this.Content<Mensaje>(HttpStatusCode.Unauthorized, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Token invalido.",
					objetoRespuesta = ex
				});
			}
			IHttpActionResult httpActionResult;
			try
			{
				if (string.IsNullOrEmpty(email))
				{
					httpActionResult = this.Content<Mensaje>(HttpStatusCode.BadRequest, new Mensaje
					{
						codigoRespuesta = "1",
						mensajeRespuesta = "Falta uno o más parámetros para realizar la consulta."
					});
				}
				else
				{
					this.perfilamientoNegocio = new PerfilamientoNegocio();
					httpActionResult = this.Content<Mensaje>(HttpStatusCode.OK, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "",
						objetoRespuesta = this.perfilamientoNegocio.ConsultarPerfilamiento(email)
					});
				}
			}
			catch (ExcepcionOperacion exOp)
			{
				httpActionResult = this.Content<Mensaje>(HttpStatusCode.InternalServerError, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Fallo en consulta.",
					objetoRespuesta = new Exception(exOp.Message, exOp.InnerException)
				});
			}
			catch (Exception ex2)
			{
				httpActionResult = this.Content<Mensaje>(HttpStatusCode.InternalServerError, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Fallo en consulta.",
					objetoRespuesta = new Exception(ex2.Message, ex2.InnerException)
				});
			}
			return httpActionResult;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002368 File Offset: 0x00000568
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
