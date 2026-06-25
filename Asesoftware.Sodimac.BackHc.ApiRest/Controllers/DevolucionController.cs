using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Asesoftware.Sodimac.BackHc.Devoluciones;
using Asesoftware.Sodimac.BackHc.DTO.Devolucion;
using Asesoftware.Sodimac.BackHc.DTO.Mensaje;
using Asesoftware.Sodimac.BackHc.Token;
using Asesoftware.Sodimac.BackHc.Utilidades.Excepciones;

namespace Asesoftware.Sodimac.BackHc.ApiRest.Controllers
{
	// Token: 0x02000005 RID: 5
	[RoutePrefix("devolucion")]
	public class DevolucionController : ApiController
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000211C File Offset: 0x0000031C
		[HttpPost]
		[Route("actualizar")]
		public async Task<IHttpActionResult> ActualizarDevolucionesAsync([FromBody] DevolucionDTO solicitud)
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
				if (!taskAwaiter.GetResult() && !this._validatoken.isBroker(re))
				{
					throw new Exception("Token invalido.");
				}
				re = null;
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
				this.devolucionNegocio = new DevolucionNegocio();
				if (this.devolucionNegocio.actualizaDevolucion(solicitud).Equals("0"))
				{
					httpActionResult = this.Content<Mensaje>(HttpStatusCode.OK, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "Actualización realizada satisfactoriamente."
					});
				}
				else
				{
					httpActionResult = this.Content<Mensaje>(HttpStatusCode.InternalServerError, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "Se presentó una irregularidad durante la actualización."
					});
				}
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

		// Token: 0x06000008 RID: 8 RVA: 0x0000216C File Offset: 0x0000036C
		[HttpGet]
		[Route("consultarCantidad")]
		public async Task<IHttpActionResult> ConsultarCantidadDevolucionesAsync(string identificacion, string tipoIdentificacion)
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
				if (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(tipoIdentificacion))
				{
					httpActionResult = this.Content<Mensaje>(HttpStatusCode.BadRequest, new Mensaje
					{
						codigoRespuesta = "1",
						mensajeRespuesta = "Falta uno o más parámetros para realizar la consulta."
					});
				}
				else
				{
					this.devolucionNegocio = new DevolucionNegocio();
					int devoluciones = this.devolucionNegocio.ConsultarCantidadDevoluciones(identificacion, tipoIdentificacion);
					httpActionResult = this.Content<Mensaje>(HttpStatusCode.OK, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "",
						objetoRespuesta = devoluciones
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

		// Token: 0x06000009 RID: 9 RVA: 0x000021C4 File Offset: 0x000003C4
		[HttpGet]
		[Route("consultar")]
		[ResponseType(typeof(Mensaje))]
		public async Task<IHttpActionResult> ConsultarDevolucionesAsync(int idSolicitudDevolucion = 0, string correo = "", string identificacion = "", string tipoIdentificacion = "", string estado = "")
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
				if (!taskAwaiter.GetResult() && !this._validatoken.isBroker(re))
				{
					throw new Exception("Token invalido.");
				}
				re = null;
			}
			catch (Exception ex)
			{
				return this.Content<Mensaje>(HttpStatusCode.Unauthorized, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Token invalido.",
					objetoRespuesta = new Exception(ex.Message, ex.InnerException)
				});
			}
			IHttpActionResult httpActionResult;
			try
			{
				if (idSolicitudDevolucion == 0 && string.IsNullOrEmpty(correo) && (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(tipoIdentificacion)))
				{
					httpActionResult = this.Content<Mensaje>(HttpStatusCode.BadRequest, new Mensaje
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
					httpActionResult = this.Content<Mensaje>(HttpStatusCode.OK, new Mensaje
					{
						codigoRespuesta = "0",
						mensajeRespuesta = "",
						objetoRespuesta = devoluciones
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

		// Token: 0x0600000A RID: 10 RVA: 0x00002234 File Offset: 0x00000434
		[HttpPost]
		[Route("crear")]
		[ResponseType(typeof(Mensaje))]
		public async Task<IHttpActionResult> CrearDevolucionesAsync([FromBody] SolicitudDTO solicitud)
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
				this.devolucionNegocio = new DevolucionNegocio();
				string idSolicitud = this.devolucionNegocio.insertarSolicitudDevolucion(solicitud);
				httpActionResult = this.Content<Mensaje>(HttpStatusCode.OK, new Mensaje
				{
					codigoRespuesta = "0",
					mensajeRespuesta = "Solicitud de devolución creada.",
					objetoRespuesta = idSolicitud
				});
			}
			catch (Exception ex2)
			{
				httpActionResult = this.Content<Mensaje>(HttpStatusCode.InternalServerError, new Mensaje
				{
					codigoRespuesta = "1",
					mensajeRespuesta = "Fallo en consulta.",
					objetoRespuesta = ex2
				});
			}
			return httpActionResult;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002284 File Offset: 0x00000484
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
