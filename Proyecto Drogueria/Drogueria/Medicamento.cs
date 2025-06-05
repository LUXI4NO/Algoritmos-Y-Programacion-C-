using System;

namespace Drogueria
{
    public class Medicamento
    {
        public string Nombre { get; set; }
        public string Droga { get; set; }
        public string Presentacion { get; set; }
        public string Laboratorio { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }

        public Medicamento(string nombre, string droga, string presentacion, string laboratorio, int stock, double precio)
        {
            Nombre = nombre;
            Droga = droga;
            Presentacion = presentacion;
            Laboratorio = laboratorio;
            Stock = stock;
            Precio = precio;
        }
    }
}