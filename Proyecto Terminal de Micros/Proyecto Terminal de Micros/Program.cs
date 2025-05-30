using System;
using System.Collections; 

namespace Practica_Parcial
{
    class Program
    {
        public static void MostrarMicrosSaltaRecursivo(ArrayList listaMicros, int indice)
        {
            
            if (indice >= listaMicros.Count)
            {
                return;
            }


            Micros microActual = (Micros)listaMicros[indice]; 


            if (microActual.Destino.ToLower() == "salta") 
            {
                Console.WriteLine("  Micro a Salta encontrado: Codigo " + microActual.Codigo + ", Patente " + microActual.Patente);
            }


            MostrarMicrosSaltaRecursivo(listaMicros, indice + 1);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("--- Inicio de la Aplicacion de Terminal de Micros ---");
            Console.WriteLine("");


            Console.WriteLine("Creando Terminal...");
            Terminal miTerminal = new Terminal("Terminal Central");
            Console.WriteLine("Terminal '" + miTerminal.Nombre + "' creada.");
            Console.WriteLine("");


            Console.WriteLine("Agregando micros a la Terminal...");

            miTerminal.AgregarMicros(new Micros(1001, "AAA-111", 1000.0, "Salta", 5, "8 horas"));
            miTerminal.AgregarMicros(new Micros(1002, "BBB-222", 800.0, "Cordoba", 4, "6 horas"));
            miTerminal.AgregarMicros(new Micros(1003, "CCC-333", 1200.0, "Salta", 6, "9 horas"));
            miTerminal.AgregarMicros(new Micros(1004, "DDD-444", 750.0, "Rosario", 3, "5 horas"));
            miTerminal.AgregarMicros(new Micros(1005, "EEE-555", 900.0, "Salta", 2, "7 horas"));
            Console.WriteLine("Micros agregados a la terminal.");
            Console.WriteLine("");


            miTerminal.VentaPasajes(); 


            Console.WriteLine("\n--- Buscando Micros con Destino Salta (Recursivo) ---");
            MostrarMicrosSaltaRecursivo(miTerminal.Micros, 0); 
            Console.WriteLine("--- Fin de Busqueda de Micros a Salta ---");

            Console.WriteLine("\n--- Fin de la Aplicacion ---");
            Console.Write("Presiona cualquier tecla para finalizar . . . ");
            Console.ReadKey(true);
        }
    }
}