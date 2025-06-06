using System;

namespace Empresa_Inmobilaria
{
    public class Operacion
    {
        public string Tipo { get; set; } // "alquiler" o "venta"
        public int Partida { get; set; }
        public string Apellido { get; set; }
        public double Valor { get; set; }

        public Operacion(string tipo, int partida, string apellido, double valor)
        {
            Tipo = tipo.ToLower();
            Partida = partida;
            Apellido = apellido;
            Valor = valor;
        }

        public double CalcularComision()
        {
            if (Tipo == "venta")
                return Valor * 0.03; // 3% comisión
            else if (Tipo == "alquiler")
                return Valor * 0.015; // 1.5% comisión
            else
                return 0;
        }
    }
}
