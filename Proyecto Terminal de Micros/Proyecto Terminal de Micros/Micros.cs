using System.Collections;
using System;

namespace Practica_Parcial
{
    public class Micros
    {
        public int Codigo { get; set; }
        public string Patente { get; set; }
        public double Precio { get; set; }
        public string Destino { get; set; }
        public int Cupo { get; set; }
        public string Duracion { get; set; } 
        public ArrayList Pasajeros { get; set; } 


        public Micros(int codigo, string patente, double precio, string destino, int cupo, string duracion)
        {
            Codigo = codigo;
            Patente = patente;
            Precio = precio;
            Destino = destino;
            Cupo = cupo;
            Duracion = duracion;
            Pasajeros = new ArrayList(); 
        }

        public bool AgregarPasajero(Pasajeros unPasajero)
        {
            if (CupoLibre() > 0) 
            {
                Pasajeros.Add(unPasajero); 
                Console.WriteLine("Pasajero " + unPasajero.DNI + " " + unPasajero.Apellido + " agregado al micro " + Codigo + ". Cupos restantes: " + CupoLibre());
                return true;
            }
            else
            {
                Console.WriteLine("No hay cupo disponible en el micro " + Codigo + ".");
                return false; 
            }
        }

        public int CupoLibre()
        {
            return Cupo - Pasajeros.Count; 
        }
    }
}