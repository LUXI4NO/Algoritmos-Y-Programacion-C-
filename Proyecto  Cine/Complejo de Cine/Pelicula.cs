using System;

namespace Complejo_de_Cine
{
	public class Pelicula
	{
		public string Titulo {get; set;}
		public string Genero {get; set;}
		public string Horario {get; set;}
		public int NumeroSala {get; set;}
		
		public Pelicula(string titulo, string genero, string horario, int numerosala)
		{
			Titulo = titulo;
			Genero = genero;
			Horario = horario;
			NumeroSala = numerosala;
			
		}
	}
}
