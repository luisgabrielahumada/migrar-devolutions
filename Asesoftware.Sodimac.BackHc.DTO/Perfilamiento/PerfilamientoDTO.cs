using System;
using System.ComponentModel.DataAnnotations;

namespace Asesoftware.Sodimac.BackHc.DTO.Perfilamiento
{
	// Token: 0x02000002 RID: 2
	public class PerfilamientoDTO
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		[Required]
		public string CEDULA { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		[Required]
		public string CLIENTE_S { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		[Required]
		public string CMR { get; set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00000283
		// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208B File Offset: 0x0000028B
		[Required]
		public string EMAIL { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002094 File Offset: 0x00000294
		// (set) Token: 0x0600000A RID: 10 RVA: 0x0000209C File Offset: 0x0000029C
		[Required]
		public string FAMILIA1 { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000020A5 File Offset: 0x000002A5
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020AD File Offset: 0x000002AD
		public string FAMILIA2 { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000020B6 File Offset: 0x000002B6
		// (set) Token: 0x0600000E RID: 14 RVA: 0x000020BE File Offset: 0x000002BE
		public string FAMILIA3 { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000020C7 File Offset: 0x000002C7
		// (set) Token: 0x06000010 RID: 16 RVA: 0x000020CF File Offset: 0x000002CF
		[Required]
		public DateTime? FECHA_ULTIMA_COMPRA { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000020D8 File Offset: 0x000002D8
		// (set) Token: 0x06000012 RID: 18 RVA: 0x000020E0 File Offset: 0x000002E0
		[Required]
		public string NOMBRE { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000020E9 File Offset: 0x000002E9
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000020F1 File Offset: 0x000002F1
		[Required]
		public string PUNTOS_CMR { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000020FA File Offset: 0x000002FA
		// (set) Token: 0x06000016 RID: 22 RVA: 0x00002102 File Offset: 0x00000302
		[Required]
		public string TIENDA_RECURRENTE { get; set; }
	}
}
