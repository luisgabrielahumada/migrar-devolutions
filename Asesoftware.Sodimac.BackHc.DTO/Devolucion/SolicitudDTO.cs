using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asesoftware.Sodimac.BackHc.DTO.Devolucion
{
	// Token: 0x02000006 RID: 6
	public class SolicitudDTO
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600006B RID: 107 RVA: 0x000023BB File Offset: 0x000005BB
		// (set) Token: 0x0600006C RID: 108 RVA: 0x000023C3 File Offset: 0x000005C3
		[Required]
		public string apellidoUsuario { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600006D RID: 109 RVA: 0x000023CC File Offset: 0x000005CC
		// (set) Token: 0x0600006E RID: 110 RVA: 0x000023D4 File Offset: 0x000005D4
		[Required]
		public string causal { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000023DD File Offset: 0x000005DD
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000023E5 File Offset: 0x000005E5
		[Required]
		[DataType(DataType.EmailAddress)]
		public string correo { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000023EE File Offset: 0x000005EE
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000023F6 File Offset: 0x000005F6
		[Required]
		public string direccion { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000023FF File Offset: 0x000005FF
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00002407 File Offset: 0x00000607
		public string estado { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00002410 File Offset: 0x00000610
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00002418 File Offset: 0x00000618
		public DateTime? fechaActualizacion { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00002421 File Offset: 0x00000621
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00002429 File Offset: 0x00000629
		public DateTime? fechaCompra
		{
			get
			{
				return this._fechaCompra;
			}
			set
			{
				this._fechaCompra = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00002432 File Offset: 0x00000632
		// (set) Token: 0x0600007A RID: 122 RVA: 0x0000243A File Offset: 0x0000063A
		public DateTime? fechaDevolucion
		{
			get
			{
				return this._fechaDevolucion;
			}
			set
			{
				this._fechaDevolucion = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00002443 File Offset: 0x00000643
		// (set) Token: 0x0600007C RID: 124 RVA: 0x0000244B File Offset: 0x0000064B
		[Required]
		public string idAlmacenPago { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00002454 File Offset: 0x00000654
		// (set) Token: 0x0600007E RID: 126 RVA: 0x0000245C File Offset: 0x0000065C
		[Required]
		public string identificacion { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00002465 File Offset: 0x00000665
		// (set) Token: 0x06000080 RID: 128 RVA: 0x0000246D File Offset: 0x0000066D
		[Required]
		public string idNotaPedido { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00002476 File Offset: 0x00000676
		// (set) Token: 0x06000082 RID: 130 RVA: 0x0000247E File Offset: 0x0000067E
		[Required]
		[Range(1.0, 9.223372036854776E+18)]
		public long idSaps { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00002487 File Offset: 0x00000687
		// (set) Token: 0x06000084 RID: 132 RVA: 0x0000248F File Offset: 0x0000068F
		public long idSolicitudDevolucion { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00002498 File Offset: 0x00000698
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000024A0 File Offset: 0x000006A0
		public string nombreEstado { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000024A9 File Offset: 0x000006A9
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000024B1 File Offset: 0x000006B1
		[Required]
		public string nombreUsuario { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000024BA File Offset: 0x000006BA
		// (set) Token: 0x0600008A RID: 138 RVA: 0x000024C2 File Offset: 0x000006C2
		public string numeroDevolucion { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000024CB File Offset: 0x000006CB
		// (set) Token: 0x0600008C RID: 140 RVA: 0x000024D3 File Offset: 0x000006D3
		public string observacion { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000024DC File Offset: 0x000006DC
		// (set) Token: 0x0600008E RID: 142 RVA: 0x000024E4 File Offset: 0x000006E4
		[Required]
		public long ordenCompra { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600008F RID: 143 RVA: 0x000024ED File Offset: 0x000006ED
		// (set) Token: 0x06000090 RID: 144 RVA: 0x000024F5 File Offset: 0x000006F5
		[Required]
		public List<DetalleSolicitudDTO> productos { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000091 RID: 145 RVA: 0x000024FE File Offset: 0x000006FE
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00002506 File Offset: 0x00000706
		[Required]
		public string sticker { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000093 RID: 147 RVA: 0x0000250F File Offset: 0x0000070F
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00002517 File Offset: 0x00000717
		public string telefono { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00002520 File Offset: 0x00000720
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00002528 File Offset: 0x00000728
		[Required]
		public string terminalPago { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00002531 File Offset: 0x00000731
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00002539 File Offset: 0x00000739
		[Required]
		public string tipoIdentificacion { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00002542 File Offset: 0x00000742
		// (set) Token: 0x0600009A RID: 154 RVA: 0x0000254A File Offset: 0x0000074A
		[Required]
		public string transaccion { get; set; }

		// Token: 0x04000034 RID: 52
		private DateTime? _fechaCompra = new DateTime?(DateTime.Now);

		// Token: 0x04000035 RID: 53
		private DateTime? _fechaDevolucion = new DateTime?(DateTime.Now);
	}
}
