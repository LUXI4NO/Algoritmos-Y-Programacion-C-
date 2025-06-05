using System;

namespace Complejo_de_Cine
{

	public class SinCapacidadExeption : Exception
	{
		public SinCapacidadExeption(string mensaje) : base(mensaje){}
	}
}
