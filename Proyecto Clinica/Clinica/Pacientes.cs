using System;

namespace Clinica
{

	public class Pacientes
	{
		public string Nombre { get; set;}
		public string Apellido { get; set;}
		public int Historial_Clinico { get; set;}
		public string DNI { get; set;}
		public string Obra_Social { get; set;}
		public string Diagnostico { get; set;}

		public Pacientes(string nombre, string apellido, int historial_clinico, string dni, string obra_social, string diagnostico)
		{
			Nombre = nombre;
			Apellido = apellido;
			Historial_Clinico = historial_clinico;
			DNI = dni;
			Obra_Social = obra_social;
			Diagnostico = diagnostico;

		}
	}
}