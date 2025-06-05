using System;

namespace Drogueria
{
	public class Pedido
	{
		public string NombreMedicamento { get; set; }
		public string Presentacion { get; set; }
		public string NombreFarmacia { get; set; }
		public int CantidadEnvases { get; set; }

		public Pedido(string nombre, string presentacion, string nombrefarmacia, int cantidad)
		{
			NombreMedicamento = nombre;
			Presentacion = presentacion;
			NombreFarmacia = nombrefarmacia;
			CantidadEnvases = cantidad;
		}
	}
}
