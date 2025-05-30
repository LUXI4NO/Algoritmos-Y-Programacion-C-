using System;
using System.Collections; 

namespace Proyecto_Herencia__2
{
    class Program 
    {
        public static void ImprimirPreciosRecursiva(ArrayList precios, int indice)
        {
            if (indice >= precios.Count)
            {
                return; 
            }

            double precioActualButaca = (double)precios[indice];

            if (precioActualButaca >= 2500)
            {
                Console.WriteLine("Procesando butaca en índice " + indice + " con precio: " + precioActualButaca);
            }
            
            ImprimirPreciosRecursiva(precios, indice + 1);
        }

        public static void Main(string[] args)
        {
            ArrayList preciosButacas = new ArrayList();

            preciosButacas.Add(100000.0);
            preciosButacas.Add(1500.0);
            preciosButacas.Add(2501.0);
            preciosButacas.Add(3000.0); 
            preciosButacas.Add(2000.0); 

            Console.WriteLine("Precios de butacas (filtrando >= 2500):");
            
            ImprimirPreciosRecursiva(preciosButacas, 0);

            Console.WriteLine("\nProceso completado. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}