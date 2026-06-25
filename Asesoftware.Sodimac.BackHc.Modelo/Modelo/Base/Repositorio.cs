using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Asesoftware.Sodimac.BackHc.DTO.BD;
using Asesoftware.Sodimac.BackHc.Entidad;

namespace Asesoftware.Sodimac.BackHc.Modelo.Base
{
	// Token: 0x02000007 RID: 7
	public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
	{
		// Token: 0x06000020 RID: 32 RVA: 0x0000242D File Offset: 0x0000062D
		public Repositorio(EntitiesAppSodimac contextApp)
		{
			this.context = contextApp;
			this.dbSet = contextApp.Set<TEntity>();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002448 File Offset: 0x00000648
		public virtual void Actualizar(TEntity entityUpdate)
		{
			this.dbSet.Attach(entityUpdate);
			this.context.Entry<TEntity>(entityUpdate).State = EntityState.Modified;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000246A File Offset: 0x0000066A
		public virtual void Adicionar(TEntity entityInsert)
		{
			this.dbSet.Add(entityInsert);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002479 File Offset: 0x00000679
		public virtual TEntity[] ConsultarFiltradoPaginado<T>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageCount, Expression<Func<TEntity, T>> orderByExpression, bool ascending)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002480 File Offset: 0x00000680
		public virtual TEntity[] ConsultarFiltrando(Expression<Func<TEntity, bool>> filter)
		{
			if (filter != null)
			{
				return this.dbSet.Where(filter).ToArray<TEntity>();
			}
			throw new ArgumentNullException("La consulta no posee la definición de un filtro");
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002479 File Offset: 0x00000679
		public virtual TEntity[] ConsultarPaginado<T>(int pageIndex, int pageCount, Expression<Func<TEntity, T>> orderByExpression, bool ascending)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000024A1 File Offset: 0x000006A1
		public virtual TEntity ConsultarPorId(int id)
		{
			return this.dbSet.Find(new object[] { id });
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000024C0 File Offset: 0x000006C0
		public T[] EjecutarProcedure<T>(ProcedimientoParametroDto param)
		{
			StringBuilder query = new StringBuilder();
			query.AppendFormat("EXEC  {0} {1};", param.NombreProcedimiento, string.Join(",", param.ArregloParametros.Select((ParametroDto w) => w.Nombre)));
			SqlParameter[] arrayParametros = new SqlParameter[param.ArregloParametros.Count];
			for (int index = 0; index < param.ArregloParametros.Count; index++)
			{
				ParametroDto item = param.ArregloParametros[index];
				arrayParametros[index] = new SqlParameter
				{
					ParameterName = item.Nombre,
					Direction = item.Direccion,
					SqlDbType = item.Tipo,
					Value = item.Valor
				};
			}
			Database database = this.context.Database;
			string text = query.ToString();
			object[] array = arrayParametros;
			return database.SqlQuery<T>(text, array).ToArray<T>();
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000025B4 File Offset: 0x000007B4
		public T[] EjecutarProcedureOutput<T>(ProcedimientoParametroDto param)
		{
			StringBuilder query = new StringBuilder();
			query.AppendFormat("EXEC  {0} {1};", param.NombreProcedimiento, string.Join(",", param.ArregloParametros.Select((ParametroDto w) => w.Nombre + w.SqlDirecion)));
			SqlParameter[] arrayParametros = new SqlParameter[param.ArregloParametros.Count];
			for (int index = 0; index < param.ArregloParametros.Count; index++)
			{
				ParametroDto item = param.ArregloParametros[index];
				arrayParametros[index] = new SqlParameter
				{
					ParameterName = item.Nombre,
					Direction = item.Direccion,
					SqlDbType = item.Tipo,
					Value = item.Valor
				};
			}
			Database database = this.context.Database;
			string text = query.ToString();
			object[] array = arrayParametros;
			T[] courseList = database.SqlQuery<T>(text, array).ToArray<T>();
			foreach (SqlParameter op in arrayParametros)
			{
				for (int index2 = 0; index2 < param.ArregloParametros.Count; index2++)
				{
					ParametroDto item2 = param.ArregloParametros[index2];
					if (op.ParameterName == item2.Nombre)
					{
						item2.Valor = op.Value;
					}
					param.ArregloParametros[index2] = item2;
				}
			}
			return courseList;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002720 File Offset: 0x00000920
		public T[] EjecutarSentenciaSQL<T>(string sentencia)
		{
			return this.context.Database.SqlQuery<T>(sentencia, new object[0]).ToArray<T>();
		}

		// Token: 0x0600002A RID: 42 RVA: 0x0000273E File Offset: 0x0000093E
		public virtual void Eliminar(TEntity entityDelete)
		{
			if (this.context.Entry<TEntity>(entityDelete).State == EntityState.Detached)
			{
				this.dbSet.Attach(entityDelete);
			}
			this.dbSet.Remove(entityDelete);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000276E File Offset: 0x0000096E
		public virtual IEnumerable<TEntity> List()
		{
			return this.dbSet.ToList<TEntity>();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000277B File Offset: 0x0000097B
		public virtual int TotalRegistros()
		{
			return this.dbSet.Count<TEntity>();
		}

		// Token: 0x04000006 RID: 6
		internal EntitiesAppSodimac context;

		// Token: 0x04000007 RID: 7
		internal DbSet<TEntity> dbSet;
	}
}
