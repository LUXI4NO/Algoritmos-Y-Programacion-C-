using System;

namespace Complejo_de_Cine
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Cine NuevoCine = new Cine("CineMark\n");
			Console.WriteLine(NuevoCine.Nombre);
			
			NuevoCine.AgregarSala(new Sala(1,30,12));
			NuevoCine.AgregarSala(new Sala(2,35,31));
			NuevoCine.AgregarSala(new Sala(3,41,5));
			NuevoCine.AgregarSala(new Sala(4,31,31));
			NuevoCine.AgregarSala(new Sala(5,12,12));
			NuevoCine.AgregarSala(new Sala(6,42,40));
			
			NuevoCine.AgregarPelicula(new Pelicula("Oppenheimer","Suspenso","10:00",5));

			bool SeguirIngresandoPeliculas = true;
			bool SeguirVendiendoEntradas = true;
			
			while(SeguirIngresandoPeliculas)
			{
				Console.WriteLine("Titulo de la pelicula: "); string titulo = Console.ReadLine();
				Console.WriteLine("Genero de la pelicula: "); string genero = Console.ReadLine();
				Console.WriteLine("Horario de la pelicula: "); string horario = Console.ReadLine();
				Console.WriteLine("Numero de sala de la pelicula: "); int numero = int.Parse(Console.ReadLine());
				
				Pelicula NuevaPelicula = new Pelicula(titulo,genero,horario,numero);
				NuevoCine.AgregarPelicula(NuevaPelicula);
				
				Console.WriteLine("Desea salir (si/no)");
				string opcion = Console.ReadLine();
				if(opcion.ToLower() == "si")
				{
					SeguirIngresandoPeliculas = false;
				}
			}
			
			while(SeguirVendiendoEntradas)
			{
				try
				{
					Console.WriteLine("Ingresar el titulo de la pelicula que desea ver: "); string TituloPeli = Console.ReadLine();
					Console.WriteLine("Ingresar el Horario de la pelicula que desea ver: "); string HorarioPeli = Console.ReadLine();
					Console.WriteLine("Ingresar La cantidad de entradas que desea comprar: "); int Cantidad = int.Parse(Console.ReadLine());
					
					NuevoCine.VentaEntradas(TituloPeli,HorarioPeli,Cantidad);
	
					Console.WriteLine("Desea salir (si/no)");
					string opcion = Console.ReadLine();
					if(opcion.ToLower() == "si")
					{
						SeguirVendiendoEntradas = false;
					}
				}
				catch(SinCapacidadExeption ex)
				{
					Console.WriteLine("ERROR: " + ex);
				}
				catch(Exception ex)
				{
					Console.WriteLine("ERROR: " + ex);
				}
				
			}
			
			NuevoCine.ResumenVentas();
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}