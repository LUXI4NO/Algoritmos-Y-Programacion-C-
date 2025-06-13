/*
 * Created by SharpDevelop.
 * User: Maguila
 * Date: 3/6/2025
 * Time: 17:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace estacionamiento
{
	public class Nivel
	{
	    private const int CapacidadMaxima = 10;
	
	    public int Numero { get;private set; }
	    public ArrayList Vehiculos { get;private set;} 
	
	    public Nivel(int numero)
	    {
	    	Vehiculos = new ArrayList();
	        Numero = numero;
	    }
	
	    public bool Estacionar(Vehiculo vehiculo)
	    {
	    	int cuposlibres = CapacidadMaxima - Vehiculos.Count;
	        if (cuposlibres > 0)
	        {
	            Vehiculos.Add(vehiculo);
	            return true;
	        }
	        return false;
	    }
	}
}
