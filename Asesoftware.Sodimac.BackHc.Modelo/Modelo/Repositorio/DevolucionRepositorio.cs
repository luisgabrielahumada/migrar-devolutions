using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Asesoftware.Sodimac.BackHc.DTO.BD;
using Asesoftware.Sodimac.BackHc.DTO.Devolucion;
using Asesoftware.Sodimac.BackHc.Entidad;
using Asesoftware.Sodimac.BackHc.Modelo.Base;

namespace Asesoftware.Sodimac.BackHc.Modelo.Repositorio
{
	// Token: 0x02000004 RID: 4
	public class DevolucionRepositorio : Repositorio<SolicitudDevolucion>
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000020CE File Offset: 0x000002CE
		public DevolucionRepositorio(EntitiesAppSodimac contextApp)
			: base(contextApp)
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000020D8 File Offset: 0x000002D8
		public string ActualizaDevolucion(DevolucionDTO devolucion)
		{
			ProcedimientoParametroDto parametro = new ProcedimientoParametroDto();
			string text;
			try
			{
				parametro.NombreProcedimiento = "[dbo].[PR_ActualizaDevolucion]";
				parametro.AdicionarParametro("@pIdSolicitud", devolucion.idSolicitudDevolucion, ParameterDirection.Input, SqlDbType.Int);
				if (!string.IsNullOrEmpty(devolucion.estado.ToString()))
				{
					parametro.AdicionarParametro("@pEstado", devolucion.estado, ParameterDirection.Input, SqlDbType.Int);
				}
				else
				{
					parametro.AdicionarParametro("@pEstado", DBNull.Value, ParameterDirection.Input, SqlDbType.Int);
				}
				if (!string.IsNullOrEmpty(devolucion.numeroDevolucion))
				{
					parametro.AdicionarParametro("@pNumeroDevolucion", devolucion.numeroDevolucion, ParameterDirection.Input, SqlDbType.VarChar);
				}
				else
				{
					parametro.AdicionarParametro("@pNumeroDevolucion", DBNull.Value, ParameterDirection.Input, SqlDbType.VarChar);
				}
				if (!string.IsNullOrEmpty(devolucion.causal))
				{
					parametro.AdicionarParametro("@pCausalSistema", devolucion.causal, ParameterDirection.Input, SqlDbType.VarChar);
				}
				else
				{
					parametro.AdicionarParametro("@pCausalSistema", DBNull.Value, ParameterDirection.Input, SqlDbType.VarChar);
				}
				if (!string.IsNullOrEmpty(devolucion.observacion))
				{
					parametro.AdicionarParametro("@pObservacion", devolucion.observacion, ParameterDirection.Input, SqlDbType.VarChar);
				}
				else
				{
					parametro.AdicionarParametro("@pObservacion", string.Empty, ParameterDirection.Input, SqlDbType.VarChar);
				}
				text = base.EjecutarProcedureOutput<string>(parametro)[0];
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return text;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002224 File Offset: 0x00000424
		public int consultaCantidadDevoluciones(string identificacion, string tipoIdentificacion)
		{
			int num;
			try
			{
				SqlParameter pIdentificacion = new SqlParameter
				{
					ParameterName = "@pIdentificacion",
					DbType = DbType.String,
					IsNullable = true,
					Value = identificacion
				};
				SqlParameter ptipoIdentificacion = new SqlParameter
				{
					ParameterName = "@pTipoIdentificacion",
					DbType = DbType.String,
					IsNullable = true,
					Value = tipoIdentificacion
				};
				num = this.context.Database.SqlQuery<int>("exec [dbo].[PR_ConsultaCantidadDevolucion]  @pIdentificacion, @pTipoIdentificacion", new object[] { pIdentificacion, ptipoIdentificacion }).SingleOrDefault<int>();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return num;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000022BC File Offset: 0x000004BC
		public List<SolicitudDevolucion> ConsultarDevolucionCompleta()
		{
			return this.context.SolicitudDevolucion.Include("DetalleSolicitudDevolucion").ToList<SolicitudDevolucion>();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022D8 File Offset: 0x000004D8
		public DevolucionDTO[] ConsultarDevoluciones(long idSolicitud, string identificacion, string tipoIdentificacion, string correo)
		{
			ProcedimientoParametroDto parametro = new ProcedimientoParametroDto();
			DevolucionDTO[] array;
			try
			{
				parametro.NombreProcedimiento = "[dbo].[PR_ConsultaDevoluciones]";
				parametro.AdicionarParametro("@pIdSolicitud", idSolicitud, ParameterDirection.Input, SqlDbType.Int);
				if (string.IsNullOrEmpty(tipoIdentificacion))
				{
					parametro.AdicionarParametro("@pIdentificacion", DBNull.Value, ParameterDirection.Input, SqlDbType.VarChar);
				}
				else
				{
					parametro.AdicionarParametro("@pIdentificacion", identificacion, ParameterDirection.Input, SqlDbType.VarChar);
				}
				if (string.IsNullOrEmpty(tipoIdentificacion))
				{
					parametro.AdicionarParametro("@pTipoIdentificacion", DBNull.Value, ParameterDirection.Input, SqlDbType.VarChar);
				}
				else
				{
					parametro.AdicionarParametro("@pTipoIdentificacion", tipoIdentificacion, ParameterDirection.Input, SqlDbType.VarChar);
				}
				if (string.IsNullOrEmpty(correo))
				{
					parametro.AdicionarParametro("@pCorreo", DBNull.Value, ParameterDirection.Input, SqlDbType.VarChar);
				}
				else
				{
					parametro.AdicionarParametro("@pCorreo", correo, ParameterDirection.Input, SqlDbType.VarChar);
				}
				array = base.EjecutarProcedureOutput<DevolucionDTO>(parametro);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return array;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000023AC File Offset: 0x000005AC
		public string CrearSolicitudDevolucion(string xmlSolicitudDevolucion)
		{
			SqlParameter xmlDevolucion = new SqlParameter
			{
				ParameterName = "@pXmlDevolucion",
				DbType = DbType.Xml,
				IsNullable = true,
				Value = xmlSolicitudDevolucion
			};
			string text;
			try
			{
				text = this.context.Database.SqlQuery<long>("exec [dbo].[PR_CrearDevolucion]  @pXmlDevolucion", new object[] { xmlDevolucion }).SingleOrDefault<long>().ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return text;
		}
	}
}
