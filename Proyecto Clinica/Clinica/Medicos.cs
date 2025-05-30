using System;

namespace Clinica
{

	public class Medicos
	{
		public string Nombre { get; set; }
		public string Legajo { get; set; }
		public string Especialidad { get; set; }

		public Medicos(string nombre, string legajo, string especialidad)
		{
			Nombre = nombre;
			Legajo = legajo;
			Especialidad = especialidad;

		}
	}
}