using System;

namespace Asesoftware.Sodimac.BackHc.Utilidades.Excepciones
{
	// Token: 0x02000003 RID: 3
	public class ExcepcionBase : Exception
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public object Referencia
		{
			get
			{
				return this._referencia;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002060 File Offset: 0x00000260
		protected ExcepcionBase(string message, object referencia, Exception innerException = null)
			: base(message, innerException)
		{
			this._referencia = referencia;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002071 File Offset: 0x00000271
		protected ExcepcionBase(string message)
			: base(message)
		{
		}

		// Token: 0x0400000A RID: 10
		private readonly object _referencia;
	}
}
