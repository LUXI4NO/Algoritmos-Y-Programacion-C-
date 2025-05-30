using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Producto normal
        Producto p1 = new Producto("Notebook", "HP", 200000, 10);
        Console.WriteLine("Precio de producto normal: " + p1.CalcularPrecio());

        // Producto en oferta
        Producto p2 = new ProductoDeOferta("Mouse", "Logitech", 5000, 20, 10); 
        Console.WriteLine("Precio de producto en oferta: " + p2.CalcularPrecio());

        Console.ReadKey();
    }
}
