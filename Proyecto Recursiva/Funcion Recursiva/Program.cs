using System;
using System.Collections;

public class Program
{
    public static void ImprimirPreciosBajosRecursiva(ArrayList precios, int indice)
    {
        if (indice >= precios.Count)
        {
            return;
        }

        double precioActual = (double)precios[indice];

        if (precioActual < 150000)
        {
            Console.WriteLine(precioActual);
        }

        ImprimirPreciosBajosRecursiva(precios, indice + 1);
    }

    public static void Main(string[] args)
    {
        ArrayList listaDePrecios = new ArrayList();
        listaDePrecios.Add(100000.0);
        listaDePrecios.Add(200000.0);
        listaDePrecios.Add(75000.50);
        listaDePrecios.Add(149999.99);
        listaDePrecios.Add(150000.0);
        listaDePrecios.Add(100.0);
        listaDePrecios.Add(300000.0);

        Console.WriteLine("Precios por debajo de 150000:");

        ImprimirPreciosBajosRecursiva(listaDePrecios, 0);

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
