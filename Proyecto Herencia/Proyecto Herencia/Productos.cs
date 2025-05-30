using System;

public class Producto
{
    // Atributos comunes
    public string Nombre { get; set; }
    public string Marca { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }

    // Constructor
    public Producto(string nombre, string marca, double precio, int stock)
    {
        Nombre = nombre;
        Marca = marca;
        Precio = precio;
        Stock = stock;
    }

    // Método polimórfico
    public virtual double CalcularPrecio()
    {
        return Precio;
    }
}

public class ProductoDeOferta : Producto
{
    // Atributo adicional
    public double PorcentajeDeDescuento { get; set; }

    // Constructor
    public ProductoDeOferta(string nombre, string marca, double precio, int stock, double porcentajeDeDescuento)
        : base(nombre, marca, precio, stock)
    {
        PorcentajeDeDescuento = porcentajeDeDescuento;
    }

    // Redefinición del método polimórfico
    public override double CalcularPrecio()
    {
        return Precio - (Precio * PorcentajeDeDescuento / 100);
    }
}

