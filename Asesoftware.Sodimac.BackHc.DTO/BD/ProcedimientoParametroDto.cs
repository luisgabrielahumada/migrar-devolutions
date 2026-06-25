using System;
using System.Collections.Generic;
using System.Data;

namespace Asesoftware.Sodimac.BackHc.DTO.BD
{
	// Token: 0x02000008 RID: 8
	public class ProcedimientoParametroDto
	{
		// Token: 0x060000A6 RID: 166 RVA: 0x000025D0 File Offset: 0x000007D0
		public ProcedimientoParametroDto()
		{
			this.arregloParametros = new List<ParametroDto>();
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x000025E3 File Offset: 0x000007E3
		public List<ParametroDto> ArregloParametros
		{
			get
			{
				return this.arregloParametros;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000025EB File Offset: 0x000007EB
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000025F3 File Offset: 0x000007F3
		public string NombreProcedimiento { get; set; }

		// Token: 0x060000AA RID: 170 RVA: 0x000025FC File Offset: 0x000007FC
		public void AdicionarParametro(string nombre, object valor)
		{
			ParametroDto parametro = default(ParametroDto);
			parametro.Nombre = nombre;
			parametro.Direccion = ParameterDirection.Input;
			parametro.Tipo = SqlDbType.VarChar;
			parametro.Valor = valor;
			parametro.SqlDirecion = "";
			this.arregloParametros.Add(parametro);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000264C File Offset: 0x0000084C
		public void AdicionarParametro(string nombre, object valor, ParameterDirection direccion, SqlDbType tipo)
		{
			ParametroDto parametro = default(ParametroDto);
			parametro.Nombre = nombre;
			parametro.Direccion = direccion;
			parametro.Tipo = tipo;
			parametro.Valor = valor;
			if (direccion == ParameterDirection.Output)
			{
				parametro.SqlDirecion = " OUTPUT";
			}
			else
			{
				parametro.SqlDirecion = "";
			}
			this.arregloParametros.Add(parametro);
		}

		// Token: 0x04000051 RID: 81
		private List<ParametroDto> arregloParametros;
	}
}
