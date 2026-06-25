using System;

namespace Asesoftware.Sodimac.BackHc.DTO.Devolucion
{
	// Token: 0x02000005 RID: 5
	public class DevolucionDTO
	{
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600002C RID: 44 RVA: 0x000021AC File Offset: 0x000003AC
		// (set) Token: 0x0600002D RID: 45 RVA: 0x000021B4 File Offset: 0x000003B4
		public string apellidoUsuario { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000021BD File Offset: 0x000003BD
		// (set) Token: 0x0600002F RID: 47 RVA: 0x000021C5 File Offset: 0x000003C5
		public int cantidad { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000030 RID: 48 RVA: 0x000021CE File Offset: 0x000003CE
		// (set) Token: 0x06000031 RID: 49 RVA: 0x000021D6 File Offset: 0x000003D6
		public string causal { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000021DF File Offset: 0x000003DF
		// (set) Token: 0x06000033 RID: 51 RVA: 0x000021E7 File Offset: 0x000003E7
		public string correo { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000021F0 File Offset: 0x000003F0
		// (set) Token: 0x06000035 RID: 53 RVA: 0x000021F8 File Offset: 0x000003F8
		public string direccion { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002201 File Offset: 0x00000401
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002209 File Offset: 0x00000409
		public int? estado { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00002212 File Offset: 0x00000412
		// (set) Token: 0x06000039 RID: 57 RVA: 0x0000221A File Offset: 0x0000041A
		public DateTime? fechaActualizacion { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00002223 File Offset: 0x00000423
		// (set) Token: 0x0600003B RID: 59 RVA: 0x0000222B File Offset: 0x0000042B
		public DateTime? fechaCompra { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00002234 File Offset: 0x00000434
		// (set) Token: 0x0600003D RID: 61 RVA: 0x0000223C File Offset: 0x0000043C
		public DateTime? fechaCreacion { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00002245 File Offset: 0x00000445
		// (set) Token: 0x0600003F RID: 63 RVA: 0x0000224D File Offset: 0x0000044D
		public DateTime? fechaPago { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00002256 File Offset: 0x00000456
		// (set) Token: 0x06000041 RID: 65 RVA: 0x0000225E File Offset: 0x0000045E
		public string idAlmacenPago { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00002267 File Offset: 0x00000467
		// (set) Token: 0x06000043 RID: 67 RVA: 0x0000226F File Offset: 0x0000046F
		public string identificacion { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00002278 File Offset: 0x00000478
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002280 File Offset: 0x00000480
		public string idNotaPedido { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00002289 File Offset: 0x00000489
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00002291 File Offset: 0x00000491
		public long idSaps { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000048 RID: 72 RVA: 0x0000229A File Offset: 0x0000049A
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000022A2 File Offset: 0x000004A2
		public long idSolicitudDevolucion { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000022AB File Offset: 0x000004AB
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000022B3 File Offset: 0x000004B3
		public string nombreEstado { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000022BC File Offset: 0x000004BC
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000022C4 File Offset: 0x000004C4
		public string nombreProducto { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000022CD File Offset: 0x000004CD
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000022D5 File Offset: 0x000004D5
		public string nombreUsuario { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000022DE File Offset: 0x000004DE
		// (set) Token: 0x06000051 RID: 81 RVA: 0x000022E6 File Offset: 0x000004E6
		public string numeroDevolucion { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000052 RID: 82 RVA: 0x000022EF File Offset: 0x000004EF
		// (set) Token: 0x06000053 RID: 83 RVA: 0x000022F7 File Offset: 0x000004F7
		public string observacion { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002300 File Offset: 0x00000500
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002308 File Offset: 0x00000508
		public long ordenCompra { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002311 File Offset: 0x00000511
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002319 File Offset: 0x00000519
		public string precio { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002322 File Offset: 0x00000522
		// (set) Token: 0x06000059 RID: 89 RVA: 0x0000232A File Offset: 0x0000052A
		public string sku { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002333 File Offset: 0x00000533
		// (set) Token: 0x0600005B RID: 91 RVA: 0x0000233B File Offset: 0x0000053B
		public string sticker { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002344 File Offset: 0x00000544
		// (set) Token: 0x0600005D RID: 93 RVA: 0x0000234C File Offset: 0x0000054C
		public string telefono { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002355 File Offset: 0x00000555
		// (set) Token: 0x0600005F RID: 95 RVA: 0x0000235D File Offset: 0x0000055D
		public string terminalPago { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002366 File Offset: 0x00000566
		// (set) Token: 0x06000061 RID: 97 RVA: 0x0000236E File Offset: 0x0000056E
		public string tipoDevolucion { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002377 File Offset: 0x00000577
		// (set) Token: 0x06000063 RID: 99 RVA: 0x0000237F File Offset: 0x0000057F
		public string tipoDevolucionNombre { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002388 File Offset: 0x00000588
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002390 File Offset: 0x00000590
		public string tipoIdentificacion { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002399 File Offset: 0x00000599
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000023A1 File Offset: 0x000005A1
		public string tipoIdentificacionNombre { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000023AA File Offset: 0x000005AA
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000023B2 File Offset: 0x000005B2
		public string transaccion { get; set; }
	}
}
