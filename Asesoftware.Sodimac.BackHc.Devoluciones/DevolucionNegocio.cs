using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Asesoftware.Sodimac.BackHc.DTO.Devolucion;
using Asesoftware.Sodimac.BackHc.Modelo.Base;

namespace Asesoftware.Sodimac.BackHc.Devoluciones
{
	// Token: 0x02000002 RID: 2
	public class DevolucionNegocio
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public string actualizaDevolucion(DevolucionDTO solicitud)
		{
			string resultado;
			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				resultado = unitOfWork.DevolucionRepositorio.ActualizaDevolucion(solicitud);
			}
			return resultado;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002090 File Offset: 0x00000290
		public int ConsultarCantidadDevoluciones(string identificacion, string tipoIdentificacion)
		{
			int devoluciones = 0;
			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				devoluciones = unitOfWork.DevolucionRepositorio.consultaCantidadDevoluciones(identificacion, tipoIdentificacion);
			}
			return devoluciones;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020D0 File Offset: 0x000002D0
		public List<SolicitudDTO> ConsultarDevoluciones(long idSolicitud, string identificacion, string tipoIdentificacion, string correo)
		{
			DevolucionDTO[] devoluciones = new DevolucionDTO[0];
			new List<SolicitudDTO>();
			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				devoluciones = unitOfWork.DevolucionRepositorio.ConsultarDevoluciones(idSolicitud, identificacion, tipoIdentificacion, correo);
			}
			return this.mapearListaDevoluciones(devoluciones);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002124 File Offset: 0x00000324
		public string insertarSolicitudDevolucion(SolicitudDTO solicitud)
		{
			string xmlSolicitud;
			using (StringWriter sw = new StringWriter())
			{
				new XmlSerializer(typeof(SolicitudDTO)).Serialize(sw, solicitud);
				xmlSolicitud = sw.ToString();
			}
			string resultado;
			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				resultado = unitOfWork.DevolucionRepositorio.CrearSolicitudDevolucion(xmlSolicitud);
			}
			return resultado;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000219C File Offset: 0x0000039C
		private List<SolicitudDTO> mapearListaDevoluciones(DevolucionDTO[] lista)
		{
			List<SolicitudDTO> listaDevoluciones = new List<SolicitudDTO>();
			for (int i = 0; i < lista.Length; i++)
			{
				DevolucionDTO devolucion = lista[i];
				if (!listaDevoluciones.Exists((SolicitudDTO x) => x.idSolicitudDevolucion == devolucion.idSolicitudDevolucion))
				{
					SolicitudDTO solicitud = new SolicitudDTO();
					solicitud.idSolicitudDevolucion = devolucion.idSolicitudDevolucion;
					solicitud.ordenCompra = devolucion.ordenCompra;
					solicitud.identificacion = devolucion.identificacion;
					solicitud.tipoIdentificacion = devolucion.tipoIdentificacion;
					solicitud.apellidoUsuario = devolucion.apellidoUsuario;
					solicitud.nombreUsuario = devolucion.nombreUsuario;
					solicitud.fechaCompra = devolucion.fechaCompra;
					solicitud.correo = devolucion.correo;
					solicitud.telefono = devolucion.telefono;
					solicitud.fechaDevolucion = devolucion.fechaCreacion;
					solicitud.estado = devolucion.estado.ToString();
					solicitud.nombreEstado = devolucion.nombreEstado;
					solicitud.numeroDevolucion = devolucion.numeroDevolucion;
					solicitud.idNotaPedido = devolucion.idNotaPedido;
					solicitud.idAlmacenPago = devolucion.idAlmacenPago;
					solicitud.terminalPago = devolucion.terminalPago;
					solicitud.transaccion = devolucion.transaccion;
					solicitud.direccion = devolucion.direccion;
					solicitud.sticker = devolucion.sticker;
					solicitud.observacion = devolucion.observacion;
					solicitud.causal = devolucion.causal;
					solicitud.fechaActualizacion = devolucion.fechaActualizacion;
					solicitud.productos = new List<DetalleSolicitudDTO>();
					DetalleSolicitudDTO producto = new DetalleSolicitudDTO();
					producto.sku = devolucion.sku;
					producto.cantidad = devolucion.cantidad;
					producto.tipoDevolucion = devolucion.tipoDevolucion;
					producto.tipoDevolucionNombre = devolucion.tipoDevolucionNombre;
					producto.nombreProducto = devolucion.nombreProducto;
					producto.precio = devolucion.precio;
					solicitud.productos.Add(producto);
					listaDevoluciones.Add(solicitud);
				}
				else
				{
					DetalleSolicitudDTO producto = new DetalleSolicitudDTO();
					producto.sku = devolucion.sku;
					producto.cantidad = devolucion.cantidad;
					producto.tipoDevolucion = devolucion.tipoDevolucion;
					producto.tipoDevolucionNombre = devolucion.tipoDevolucionNombre;
					producto.nombreProducto = devolucion.nombreProducto;
					producto.precio = devolucion.precio;
					listaDevoluciones.Find((SolicitudDTO sol) => sol.idSolicitudDevolucion == devolucion.idSolicitudDevolucion).productos.Add(producto);
				}
			}
			return listaDevoluciones;
		}
	}
}
