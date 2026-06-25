using System;
using System.Data;

namespace Asesoftware.Sodimac.BackHc.DTO.BD
{
	// Token: 0x02000007 RID: 7
	public struct ParametroDto
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600009C RID: 156 RVA: 0x0000257B File Offset: 0x0000077B
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00002583 File Offset: 0x00000783
		public ParameterDirection Direccion
		{
			get
			{
				return this.direccion;
			}
			set
			{
				this.direccion = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000258C File Offset: 0x0000078C
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00002594 File Offset: 0x00000794
		public string Nombre
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = value;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x0000259D File Offset: 0x0000079D
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x000025A5 File Offset: 0x000007A5
		public string SqlDirecion
		{
			get
			{
				return this.sqlDirecion;
			}
			set
			{
				this.sqlDirecion = value;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x000025AE File Offset: 0x000007AE
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x000025B6 File Offset: 0x000007B6
		public SqlDbType Tipo
		{
			get
			{
				return this.tipo;
			}
			set
			{
				this.tipo = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000025BF File Offset: 0x000007BF
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000025C7 File Offset: 0x000007C7
		public object Valor
		{
			get
			{
				return this.valor;
			}
			set
			{
				this.valor = value;
			}
		}

		// Token: 0x0400004C RID: 76
		private ParameterDirection direccion;

		// Token: 0x0400004D RID: 77
		private string nombre;

		// Token: 0x0400004E RID: 78
		private string sqlDirecion;

		// Token: 0x0400004F RID: 79
		private SqlDbType tipo;

		// Token: 0x04000050 RID: 80
		private object valor;
	}
}
