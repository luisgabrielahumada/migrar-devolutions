using System;
using System.Linq;
using Asesoftware.Sodimac.BackHc.DTO.Perfilamiento;
using Asesoftware.Sodimac.BackHc.Entidad;
using Asesoftware.Sodimac.BackHc.Modelo.Base;
using AutoMapper;

namespace Asesoftware.Sodimac.BackHc.Perfilamientos
{
	// Token: 0x02000002 RID: 2
	public class PerfilamientoNegocio
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public void ActualizarPerfilamiento(PerfilamientoDTO perfilamiento)
		{
			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				try
				{
					Mapper.Initialize(delegate(IMapperConfigurationExpression cfg)
					{
						cfg.CreateMap<Perfilamiento, PerfilamientoDTO>();
					});
					Perfilamiento PefilamientoObj = Mapper.Map<Perfilamiento>(perfilamiento);
					if (this.ConsultarPerfilamiento(perfilamiento.EMAIL).Count<Perfilamiento>() > 0)
					{
						unitOfWork.PerfilamientoRepositorio.Actualizar(PefilamientoObj);
					}
					else
					{
						unitOfWork.PerfilamientoRepositorio.Adicionar(PefilamientoObj);
					}
					unitOfWork.Save();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Mapper.Reset();
				}
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002100 File Offset: 0x00000300
		public Perfilamiento[] ConsultarPerfilamiento(string email)
		{
			Perfilamiento[] perfilamiento = new Perfilamiento[0];
			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				perfilamiento = unitOfWork.PerfilamientoRepositorio.ConsultarFiltrando((Perfilamiento p) => p.EMAIL == email).ToArray<Perfilamiento>();
			}
			return perfilamiento;
		}
	}
}
