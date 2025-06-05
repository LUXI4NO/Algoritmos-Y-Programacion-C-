using System;
using System.Collections;

namespace Complejo_de_Cine
{
	public class Cine
	{
		public string Nombre{get;set;}
		public ArrayList Salas;
		public ArrayList Peliculas;
		private double PrecioEntrada = 1500; 
		private int TotalEntradasVendidas = 0;
		private int EntradasSuspenso = 0;

		
		public Cine(string nombre)
		{
			Nombre = nombre;
			Salas = new ArrayList();
			Peliculas = new ArrayList();
		}
		
		
		public void AgregarSala(Sala NuevaSala)
		{
			Salas.Add(NuevaSala);
			Console.WriteLine("Se agrego la sala " + NuevaSala.Numero + " con una capacidad para " + NuevaSala.Capacidad + " y tiene un total de entradas de: " + NuevaSala.CantidadEntradasVendidas);
		}
		
		public void AgregarPelicula(Pelicula NuevaPelicula)
		{
			Peliculas.Add(NuevaPelicula);
			Console.WriteLine("Se agrego la Pelicula " + NuevaPelicula.Titulo + " de genero " + NuevaPelicula.Genero + " en el horario " + NuevaPelicula.Horario + "en la sala: " + NuevaPelicula.NumeroSala);
		}
		
		public void VentaEntradas(string TituloPeli, string HorarioPeli, int Cantidad)
		{
		    bool encontrada = false;
		
		    foreach (Pelicula p in Peliculas)
		    {
		        if (p.Titulo.Trim().ToLower() == TituloPeli.Trim().ToLower() &&
		            p.Horario.Trim().ToLower() == HorarioPeli.Trim().ToLower())
		        {
		            foreach (Sala s in Salas)
		            {
		                if (s.Numero == p.NumeroSala)
		                {
		                    int disponibles = s.Capacidad - s.CantidadEntradasVendidas;
		                    if (disponibles >= Cantidad)
		                    {
		                        s.CantidadEntradasVendidas += Cantidad;
		                        TotalEntradasVendidas += Cantidad;
		
		                        if (p.Genero.Trim().ToLower() == "suspenso")
		                        {
		                            EntradasSuspenso += Cantidad;
		                        }
		
		                        Console.WriteLine("Venta realizada con éxito.");
		                    }
		                    else
		                    {
		                        Console.WriteLine("No hay entradas suficientes.");
		                    }
		
		                    encontrada = true;
		                    break;
		                }
		            }
		        }
		    }
		
		    if (!encontrada)
		    {
		        Console.WriteLine("No se encontró la película con ese título y horario.");
		    }
		}

		
		public void ResumenVentas()
		{
		    double MontoTotal = TotalEntradasVendidas * PrecioEntrada;
		    double PorcentajeSuspenso = TotalEntradasVendidas > 0 ? 
		    (double)EntradasSuspenso / TotalEntradasVendidas * 100 : 0;
		
		    Console.WriteLine("\n--- RESUMEN DE VENTAS ---");
		    Console.WriteLine("Monto total recaudado: $" + MontoTotal);
		    Console.WriteLine("Porcentaje de entradas vendidas para películas de suspenso: " + PorcentajeSuspenso.ToString("F2") + "%");
		    Console.WriteLine("Listado de entradas vendidas por sala:");
		
		    foreach (Sala s in Salas)
		    {
		        Console.WriteLine("Sala Nº " + s.Numero + " → Entradas vendidas: " + s.CantidadEntradasVendidas);
		    }
		}


	}
}
