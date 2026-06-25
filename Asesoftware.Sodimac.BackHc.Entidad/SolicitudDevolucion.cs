using System;
using System.Collections.Generic;

namespace Asesoftware.Sodimac.BackHc.Entidad
{
	// Token: 0x02000006 RID: 6
	public class SolicitudDevolucion
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002247 File Offset: 0x00000447
		public SolicitudDevolucion()
		{
			this.DetalleSolicitudDevolucion = new HashSet<DetalleSolicitudDevolucion>();
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003E RID: 62 RVA: 0x0000225A File Offset: 0x0000045A
		// (set) Token: 0x0600003F RID: 63 RVA: 0x00002262 File Offset: 0x00000462
		public long IdSolicitudDevolucion { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000226B File Offset: 0x0000046B
		// (set) Token: 0x06000041 RID: 65 RVA: 0x00002273 File Offset: 0x00000473
		public long OrdenCompra { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000042 RID: 66 RVA: 0x0000227C File Offset: 0x0000047C
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00002284 File Offset: 0x00000484
		public long IdSaps { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000228D File Offset: 0x0000048D
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002295 File Offset: 0x00000495
		public string Identificacion { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000229E File Offset: 0x0000049E
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000022A6 File Offset: 0x000004A6
		public string TipoIdentificacion { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000022AF File Offset: 0x000004AF
		// (set) Token: 0x06000049 RID: 73 RVA: 0x000022B7 File Offset: 0x000004B7
		public string TipoIdentificacionNombre { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000022C0 File Offset: 0x000004C0
		// (set) Token: 0x0600004B RID: 75 RVA: 0x000022C8 File Offset: 0x000004C8
		public string NombreUsuario { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000022D1 File Offset: 0x000004D1
		// (set) Token: 0x0600004D RID: 77 RVA: 0x000022D9 File Offset: 0x000004D9
		public string ApellidoUsuario { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000022E2 File Offset: 0x000004E2
		// (set) Token: 0x0600004F RID: 79 RVA: 0x000022EA File Offset: 0x000004EA
		public string Correo { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000050 RID: 80 RVA: 0x000022F3 File Offset: 0x000004F3
		// (set) Token: 0x06000051 RID: 81 RVA: 0x000022FB File Offset: 0x000004FB
		public string Telefono { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002304 File Offset: 0x00000504
		// (set) Token: 0x06000053 RID: 83 RVA: 0x0000230C File Offset: 0x0000050C
		public string Direccion { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002315 File Offset: 0x00000515
		// (set) Token: 0x06000055 RID: 85 RVA: 0x0000231D File Offset: 0x0000051D
		public int Estado { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002326 File Offset: 0x00000526
		// (set) Token: 0x06000057 RID: 87 RVA: 0x0000232E File Offset: 0x0000052E
		public DateTime? FechaCreacion { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002337 File Offset: 0x00000537
		// (set) Token: 0x06000059 RID: 89 RVA: 0x0000233F File Offset: 0x0000053F
		public DateTime? FechaActualizacion { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002348 File Offset: 0x00000548
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002350 File Offset: 0x00000550
		public DateTime? FechaCompra { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002359 File Offset: 0x00000559
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002361 File Offset: 0x00000561
		public string IdNotaPedido { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600005E RID: 94 RVA: 0x0000236A File Offset: 0x0000056A
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002372 File Offset: 0x00000572
		public string IdAlmacenPago { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000060 RID: 96 RVA: 0x0000237B File Offset: 0x0000057B
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00002383 File Offset: 0x00000583
		public string TerminalPago { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000062 RID: 98 RVA: 0x0000238C File Offset: 0x0000058C
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00002394 File Offset: 0x00000594
		public string Transaccion { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000064 RID: 100 RVA: 0x0000239D File Offset: 0x0000059D
		// (set) Token: 0x06000065 RID: 101 RVA: 0x000023A5 File Offset: 0x000005A5
		public DateTime? FechaPago { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000023AE File Offset: 0x000005AE
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000023B6 File Offset: 0x000005B6
		public string Sticker { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000068 RID: 104 RVA: 0x000023BF File Offset: 0x000005BF
		// (set) Token: 0x06000069 RID: 105 RVA: 0x000023C7 File Offset: 0x000005C7
		public string NumeroDevolucion { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600006A RID: 106 RVA: 0x000023D0 File Offset: 0x000005D0
		// (set) Token: 0x0600006B RID: 107 RVA: 0x000023D8 File Offset: 0x000005D8
		public string Causal { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600006C RID: 108 RVA: 0x000023E1 File Offset: 0x000005E1
		// (set) Token: 0x0600006D RID: 109 RVA: 0x000023E9 File Offset: 0x000005E9
		public string Observacion { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000023F2 File Offset: 0x000005F2
		// (set) Token: 0x0600006F RID: 111 RVA: 0x000023FA File Offset: 0x000005FA
		public virtual ICollection<DetalleSolicitudDevolucion> DetalleSolicitudDevolucion { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000070 RID: 112 RVA: 0x00002403 File Offset: 0x00000603
		// (set) Token: 0x06000071 RID: 113 RVA: 0x0000240B File Offset: 0x0000060B
		public virtual Estado Estado1 { get; set; }
	}
}
