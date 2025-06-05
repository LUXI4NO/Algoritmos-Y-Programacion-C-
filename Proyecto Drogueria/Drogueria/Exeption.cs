using System;

namespace Drogueria
{
	public class StockInsuficienteException : Exception
	{
		public StockInsuficienteException(string mensaje) : base(mensaje) { }
	}
}
