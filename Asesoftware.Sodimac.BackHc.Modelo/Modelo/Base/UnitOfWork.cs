using System;
using Asesoftware.Sodimac.BackHc.Entidad;
using Asesoftware.Sodimac.BackHc.Modelo.Repositorio;

namespace Asesoftware.Sodimac.BackHc.Modelo.Base
{
	// Token: 0x02000008 RID: 8
	public class UnitOfWork : IDisposable
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002788 File Offset: 0x00000988
		public DevolucionRepositorio DevolucionRepositorio
		{
			get
			{
				if (this.devolucionRepositorio == null)
				{
					this.devolucionRepositorio = new DevolucionRepositorio(this.context);
				}
				return this.devolucionRepositorio;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000027A9 File Offset: 0x000009A9
		public PerfilamientoRepositorio PerfilamientoRepositorio
		{
			get
			{
				if (this.perfilamientoRepositorio == null)
				{
					this.perfilamientoRepositorio = new PerfilamientoRepositorio(this.context);
				}
				return this.perfilamientoRepositorio;
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000027CA File Offset: 0x000009CA
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000027D9 File Offset: 0x000009D9
		public void Save()
		{
			this.context.SaveChanges();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000027E7 File Offset: 0x000009E7
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed && disposing)
			{
				this.context.Dispose();
			}
			this.disposed = true;
		}

		// Token: 0x04000008 RID: 8
		private EntitiesAppSodimac context = new EntitiesAppSodimac();

		// Token: 0x04000009 RID: 9
		private DevolucionRepositorio devolucionRepositorio;

		// Token: 0x0400000A RID: 10
		private bool disposed;

		// Token: 0x0400000B RID: 11
		private PerfilamientoRepositorio perfilamientoRepositorio;
	}
}
