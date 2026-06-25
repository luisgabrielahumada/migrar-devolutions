using System;
using System.Diagnostics;

namespace Asesoftware.Sodimac.BackHc.Utilidades.Excepciones
{
	// Token: 0x02000004 RID: 4
	public class ExcepcionOperacion : ExcepcionBase
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000207A File Offset: 0x0000027A
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00002082 File Offset: 0x00000282
		public int Codigo
		{
			get
			{
				return this._codigo;
			}
			set
			{
				this._codigo = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000208B File Offset: 0x0000028B
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002093 File Offset: 0x00000293
		public string Operacion
		{
			get
			{
				return this._operacion;
			}
			set
			{
				this._operacion = value;
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000209C File Offset: 0x0000029C
		public ExcepcionOperacion(string message, int codigo, object data, Exception innerException = null)
			: base(message, data, innerException)
		{
			this._codigo = codigo;
			this._operacion = this.ObtenerMetodo();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020BB File Offset: 0x000002BB
		public string ObtenerMetodo()
		{
			return new StackTrace().GetFrame(2).GetMethod().Name;
		}

		// Token: 0x0400000B RID: 11
		private int _codigo;

		// Token: 0x0400000C RID: 12
		private string _operacion;
	}
}
