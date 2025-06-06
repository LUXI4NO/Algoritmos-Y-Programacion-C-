using System;
using System.Collections;

namespace Empresa_Inmobilaria
{
    public class Empresa
    {
        public string Nombre { get; set; }
        public ArrayList Sucursales { get; set; }

        public Empresa(string nombre)
        {
            Nombre = nombre;
            Sucursales = new ArrayList();
        }

        public void AgregarSucursal(Sucursal sucursal)
        {
            Sucursales.Add(sucursal);
        }

        public Sucursal BuscarSucursalPorCodigo(int codigo)
        {
            foreach (Sucursal s in Sucursales)
            {
                if (s.Codigo == codigo)
                    return s;
            }
            return null;
        }
    }
}
