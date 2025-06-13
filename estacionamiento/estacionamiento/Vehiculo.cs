 /*
 * Created by SharpDevelop.
 * User: Maguila
 * Date: 3/6/2025
 * Time: 17:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace estacionamiento
{
	public class Vehiculo
	{
	    public string Patente { get; set; }
	    public string Tipo { get; set; }
	    public decimal MontoAbonado { get; set; }
	    public int Periodo { get; set; }
	
	    public Vehiculo(string patente, string tipo, decimal monto, int periodo)
	    {
	        Patente = patente;
	        Tipo = tipo;
	        MontoAbonado = monto;
	        Periodo = periodo;
	    }
	}
}
