using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Asesoftware.Sodimac.BackHc.DTO.BD;

namespace Asesoftware.Sodimac.BackHc.Modelo.Base
{
	// Token: 0x02000006 RID: 6
	public interface IRepositorio<TEntity> where TEntity : class
	{
		// Token: 0x06000015 RID: 21
		void Actualizar(TEntity entity);

		// Token: 0x06000016 RID: 22
		void Adicionar(TEntity entity);

		// Token: 0x06000017 RID: 23
		TEntity[] ConsultarFiltradoPaginado<T>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageCount, Expression<Func<TEntity, T>> orderByExpression, bool ascending);

		// Token: 0x06000018 RID: 24
		TEntity[] ConsultarFiltrando(Expression<Func<TEntity, bool>> filter);

		// Token: 0x06000019 RID: 25
		TEntity[] ConsultarPaginado<T>(int pageIndex, int pageCount, Expression<Func<TEntity, T>> orderByExpression, bool ascending);

		// Token: 0x0600001A RID: 26
		TEntity ConsultarPorId(int Id);

		// Token: 0x0600001B RID: 27
		T[] EjecutarProcedure<T>(ProcedimientoParametroDto param);

		// Token: 0x0600001C RID: 28
		T[] EjecutarProcedureOutput<T>(ProcedimientoParametroDto param);

		// Token: 0x0600001D RID: 29
		void Eliminar(TEntity entity);

		// Token: 0x0600001E RID: 30
		IEnumerable<TEntity> List();

		// Token: 0x0600001F RID: 31
		int TotalRegistros();
	}
}
