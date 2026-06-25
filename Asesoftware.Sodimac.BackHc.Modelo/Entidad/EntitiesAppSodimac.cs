using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Asesoftware.Sodimac.BackHc.Entidad
{
	// Token: 0x02000002 RID: 2
	public class EntitiesAppSodimac : DbContext
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public EntitiesAppSodimac()
			: base("name=EntitiesAppSodimac")
		{
			base.Configuration.LazyLoadingEnabled = false;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002069 File Offset: 0x00000269
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			throw new UnintentionalCodeFirstException();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002070 File Offset: 0x00000270
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002078 File Offset: 0x00000278
		public virtual DbSet<Auditoria> Auditoria { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002081 File Offset: 0x00000281
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00002089 File Offset: 0x00000289
		public virtual DbSet<DetalleSolicitudDevolucion> DetalleSolicitudDevolucion { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002092 File Offset: 0x00000292
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000209A File Offset: 0x0000029A
		public virtual DbSet<Estado> Estado { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020A3 File Offset: 0x000002A3
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020AB File Offset: 0x000002AB
		public virtual DbSet<Perfilamiento> Perfilamiento { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020B4 File Offset: 0x000002B4
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020BC File Offset: 0x000002BC
		public virtual DbSet<SolicitudDevolucion> SolicitudDevolucion { get; set; }
	}
}
