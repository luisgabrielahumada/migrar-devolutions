using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asesoftware.Sodimac.BackHc.Devoluciones;
using Asesoftware.Sodimac.BackHc.DTO.Devolucion;
using Asesoftware.Sodimac.BackHc.DTO.Mensaje;
using Asesoftware.Sodimac.BackHc.Token;
using Asesoftware.Sodimac.BackHc.Utilidades.Excepciones;

namespace Asesoftware.Sodimac.BackHc.ApiRest.Controllers
{
	// Token: 0x02000005 RID: 5
	[ApiController]
	[Route("devolucion")]
	public class DevolucionController : ControllerBase
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000211C File Offset: 0x0000031C
		[HttpPost]
		[Route("actualizar")]
		public async Task<IActionResult> ActualizarDevolucionesAsync([FromBody] DevolucionDTO solicitud)
		{
			try
			{
				var re = Request;
				this._validatoken = new TokenValidacion();
				if (!await this._validatoken.ValidarAsync(re) && !this._validatoken.isBroker(re))
				{
					throw new Exception("Token invalido.");
				}
				re = null;
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
				this.devolucionNegocio = new DevolucionNegocio();
				if (this.devolucionNegocio.actualizaDevolucion(solicitud).Equals("0"))
				{
					httpActionResult = StatusCode((int)HttpStatusCode.OK, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "Actualización realizada satisfactoriamente."
					});
				}
				else
				{
					httpActionResult = StatusCode((int)HttpStatusCode.InternalServerError, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "Se presentó una irregularidad durante la actualización."
					});
				}
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

		// Token: 0x06000008 RID: 8 RVA: 0x0000216C File Offset: 0x0000036C
		[HttpGet]
		[Route("consultarCantidad")]
		public async Task<IActionResult> ConsultarCantidadDevolucionesAsync(string identificacion, string tipoIdentificacion)
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
				if (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(tipoIdentificacion))
				{
					httpActionResult = StatusCode((int)HttpStatusCode.BadRequest, new Mensaje
					{
						codigoRespuesta = "1",
						mensajeRespuesta = "Falta uno o más parámetros para realizar la consulta."
					});
				}
				else
				{
					this.devolucionNegocio = new DevolucionNegocio();
					int devoluciones = this.devolucionNegocio.ConsultarCantidadDevoluciones(identificacion, tipoIdentificacion);
					httpActionResult = StatusCode((int)HttpStatusCode.OK, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "",
						objetoRespuesta = devoluciones
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

		// Token: 0x06000009 RID: 9 RVA: 0x000021C4 File Offset: 0x000003C4
		[HttpGet]
		[Route("consultar")]
				public async Task<IActionResult> ConsultarDevolucionesAsync(int idSolicitudDevolucion = 0, string correo = "", string identificacion = "", string tipoIdentificacion = "", string estado = "")
		{
			try
			{
				var re = Request;
				this._validatoken = new TokenValidacion();
				if (!await this._validatoken.ValidarAsync(re) && !this._validatoken.isBroker(re))
				{
					throw new Exception("Token invalido.");
				}
				re = null;
			}
			catch (Exception ex)
			{
				return StatusCode((int)HttpStatusCode.Unauthorized, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Token invalido.",
					objetoRespuesta = new Exception(ex.Message, ex.InnerException)
				});
			}
			IActionResult httpActionResult;
			try
			{
				if (idSolicitudDevolucion == 0 && string.IsNullOrEmpty(correo) && (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(tipoIdentificacion)))
				{
					httpActionResult = StatusCode((int)HttpStatusCode.BadRequest, new Mensaje
					{
						codigoRespuesta = "1",
						mensajeRespuesta = "Falta uno o más parámetros para realizar la consulta."
					});
				}
				else
				{
					this.devolucionNegocio = new DevolucionNegocio();
					List<SolicitudDTO> devoluciones = this.devolucionNegocio.ConsultarDevoluciones((long)idSolicitudDevolucion, identificacion, tipoIdentificacion, correo);
					if (devoluciones.Count > 0 && !string.IsNullOrEmpty(estado))
					{
						devoluciones = devoluciones.FindAll((SolicitudDTO p) => p.estado == estado);
					}
					httpActionResult = StatusCode((int)HttpStatusCode.OK, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "",
						objetoRespuesta = devoluciones
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

		// Token: 0x0600000A RID: 10 RVA: 0x00002234 File Offset: 0x00000434
		[HttpPost]
		[Route("crear")]
				public async Task<IActionResult> CrearDevolucionesAsync([FromBody] SolicitudDTO solicitud)
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
				this.devolucionNegocio = new DevolucionNegocio();
				string idSolicitud = this.devolucionNegocio.insertarSolicitudDevolucion(solicitud);
				httpActionResult = StatusCode((int)HttpStatusCode.OK, new Mensaje
				{
					codigoRespuesta = "0",
					mensajeRespuesta = "Solicitud de devolución creada.",
					objetoRespuesta = idSolicitud
				});
			}
			catch (Exception ex2)
			{
				httpActionResult = StatusCode((int)HttpStatusCode.InternalServerError, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Fallo en consulta.",
					objetoRespuesta = ex2
				});
			}
			return httpActionResult;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002284 File Offset: 0x00000484
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

		// Token: 0x04000001 RID: 1
		private TokenValidacion _validatoken;

		// Token: 0x04000002 RID: 2
		private DevolucionNegocio devolucionNegocio;
	}
}
