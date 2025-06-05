using System;

namespace Complejo_de_Cine
{
	public class Sala
	{
		public int Numero {get; set;}
		public int Capacidad {get; set;}
		public int CantidadEntradasVendidas {get; set;}
		
		public Sala(int numero, int capacidad, int CantidadEntradas)
		{
			Numero = numero;
			Capacidad = capacidad;
			CantidadEntradasVendidas = CantidadEntradas;
		}
		
		
		
	}
}
