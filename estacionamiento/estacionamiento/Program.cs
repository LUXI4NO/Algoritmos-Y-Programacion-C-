/*
 * Created by SharpDevelop.
 * User: Maguila
 * Date: 3/6/2025
 * Time: 17:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace estacionamiento
{
	class Program
	{
		
	    public static void MostrarMotosEnNivel(Nivel nivel, int index = 0)
	    {
	        if (index >= nivel.Vehiculos.Count)
	            return;
	
	        Vehiculo vehiculo = (Vehiculo)nivel.Vehiculos[index];
	        if (vehiculo.Tipo == "moto")
	        {
	            Console.WriteLine("Patente Moto: " + vehiculo.Patente);
	        }
	
	        MostrarMotosEnNivel(nivel, index + 1);
	    }
		    
		public static void Main(string[] args)
		{
			Estacionamiento estacionamiento = new Estacionamiento();
	        estacionamiento.RegistrarIngreso("ABC123", "auto", 1);
	        estacionamiento.RegistrarIngreso("XYZ789", "moto", 6);
	        estacionamiento.RegistrarIngreso("DEF456", "combi", 25);
	        estacionamiento.RegistrarIngreso("GHI789", "moto", 1);
	        estacionamiento.RegistrarIngreso("JKL012", "auto", 6);
	        estacionamiento.RegistrarIngreso("ZZZ999", "moto", 6); 
	        estacionamiento.RegistrarIngreso("AAA111", "auto", 1);
	        estacionamiento.RegistrarIngreso("BBB222", "moto", 25);
	        estacionamiento.RegistrarIngreso("CCC333", "auto", 1);
	        estacionamiento.RegistrarIngreso("DDD444", "moto", 1);
	        estacionamiento.RegistrarIngreso("EEE555", "auto", 25);
	        estacionamiento.RegistrarIngreso("FFF666", "moto", 6); 
	
	        Console.WriteLine("\n Informe Final:");
	        Console.WriteLine(" Recaudación mensual total: $" + estacionamiento.recaudacionMensual.ToString("F2"));
	        Console.WriteLine(" Porcentaje de solicitudes rechazadas: " + estacionamiento.PorcentajeRechazos().ToString("F2") + "%");
	
	        Console.WriteLine("\n Motos estacionadas en el nivel 1:");
	        Nivel primerNivel = (Nivel)estacionamiento.Niveles[0];
	        MostrarMotosEnNivel(primerNivel, 0);
	        Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
    	}
	}
}