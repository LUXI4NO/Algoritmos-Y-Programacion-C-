/*
 * Created by SharpDevelop.
 * User: Maguila
 * Date: 3/6/2025
 * Time: 17:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace estacionamiento
{
	public class Estacionamiento
	{
	    public ArrayList Niveles; 
	    public decimal recaudacionMensual {get;private set;}
	    private int solicitudesTotales = 0;
	    private int solicitudesRechazadas = 0;
	
	    public Estacionamiento()
	    {
	    	Niveles = new ArrayList();
	    	recaudacionMensual = 0;
	        for (int i = 1; i <= 5; i++)
	        {
	            Niveles.Add(new Nivel(i));
	        }
	    }
	
	    public void RegistrarIngreso(string patente, string tipo, int periodo)
	    {
	        solicitudesTotales++;
	
	        decimal tarifa = CalcularTarifa(tipo, periodo);
	        Vehiculo nuevoVehiculo = new Vehiculo(patente, tipo, tarifa, periodo);
	
	        foreach (Nivel nivel in Niveles)
	        {
	            if (nivel.Estacionar(nuevoVehiculo))
	            {
	                Console.WriteLine("Vehículo " + patente + " asignado al nivel " + ((Nivel)nivel).Numero +
	                                  ". Monto abonado: $" + tarifa.ToString("F2"));
	                recaudacionMensual += tarifa;
	                return;
	            }
	        }
	
	        Console.WriteLine("No hay cupo disponible para el vehículo " + patente);
	        solicitudesRechazadas++;
	    }
	
	    public double PorcentajeRechazos()
	    {
	        if (solicitudesTotales == 0) return 0;
	        return (double)solicitudesRechazadas / solicitudesTotales * 100;
	    }
	
	    private int CalcularTarifa(string tipo, int periodo)
	    {
	        int baseTarifa = 20;
	        if (tipo == "moto") baseTarifa = 10;
	        else if (tipo == "camioneta") baseTarifa = 30;
	        else if (tipo == "combi") baseTarifa = 40;
	        return baseTarifa * periodo;
	    }
	}
}
