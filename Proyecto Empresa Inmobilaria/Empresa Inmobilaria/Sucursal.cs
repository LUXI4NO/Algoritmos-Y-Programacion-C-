using System;
using System.Collections;

namespace Empresa_Inmobilaria
{
    public class Sucursal
    {
        public int Codigo { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public ArrayList Operaciones { get; set; }

        public Sucursal(int codigo, string direccion, string localidad)
        {
            Codigo = codigo;
            Direccion = direccion;
            Localidad = localidad;
            Operaciones = new ArrayList();
        }

        public void AtenderCliente(Operacion nuevaOperacion)
        {
            Operaciones.Add(nuevaOperacion);
            Console.WriteLine("Operación registrada: " + nuevaOperacion.Tipo + " - Cliente: " + nuevaOperacion.Apellido);
            Console.WriteLine("Comisión generada: $" + nuevaOperacion.CalcularComision());
        }
    }
    
}
