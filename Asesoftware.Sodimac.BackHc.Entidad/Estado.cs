using System;
using System.Collections.Generic;

namespace Asesoftware.Sodimac.BackHc.Entidad
{
	// Token: 0x02000004 RID: 4
	public class Estado
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002146 File Offset: 0x00000346
		public Estado()
		{
			this.SolicitudDevolucion = new HashSet<SolicitudDevolucion>();
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000020 RID: 32 RVA: 0x00002159 File Offset: 0x00000359
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002161 File Offset: 0x00000361
		public int id { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000022 RID: 34 RVA: 0x0000216A File Offset: 0x0000036A
		// (set) Token: 0x06000023 RID: 35 RVA: 0x00002172 File Offset: 0x00000372
		public string nombre { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000217B File Offset: 0x0000037B
		// (set) Token: 0x06000025 RID: 37 RVA: 0x00002183 File Offset: 0x00000383
		public virtual ICollection<SolicitudDevolucion> SolicitudDevolucion { get; set; }
	}
}
