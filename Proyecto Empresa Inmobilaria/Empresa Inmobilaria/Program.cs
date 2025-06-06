using System;
using System.Collections;

namespace Empresa_Inmobilaria
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int a = 5;
                int b = 25;
                Console.WriteLine(b + "es múltiplo de " + a + " ? " + Multiplo(a, b));
            }
            catch (NoCalculoMultiploExpetion ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Otro error: " + ex.Message);
            }
			
            Console.WriteLine("");
			Empresa NuevaEmpresa = new Empresa("HogarDulceHogar");
			Console.WriteLine(NuevaEmpresa.Nombre);
			
			NuevaEmpresa.AgregarSucursal(new Sucursal(1,"Primera Direccion","Primera Localidad"));
			NuevaEmpresa.AgregarSucursal(new Sucursal(2,"Segunda Direccion","Segunda Localidad"));
			
			bool Seguir = true;
			bool Seguir1 = true;
			

			

			while(Seguir)
			{
				Console.WriteLine("\n--- Ingresar Nueva Sucursal ---");
				
				Console.WriteLine("Codigo: "); int Codigo = int.Parse(Console.ReadLine());
				Console.WriteLine("Direccion: "); string Direccion = Console.ReadLine();
				Console.WriteLine("Localidad: "); string Localidad = Console.ReadLine();
				
				Sucursal NuevaSucursal = new Sucursal(Codigo,Direccion,Localidad);
				NuevaEmpresa.AgregarSucursal(NuevaSucursal);
				
				
				Console.WriteLine("Desea salir (si/no)");
				string opcion = Console.ReadLine();
				if(opcion.ToLower() == "si")
				{
					Seguir = false;
				}
			}
			
            while (Seguir1)
            {
                Console.WriteLine("\n--- Atención al Cliente ---");

                Console.Write("Apellido del cliente: ");
                string apellido = Console.ReadLine();

                Console.Write("Código de la sucursal: ");
                int codigo = int.Parse(Console.ReadLine());

                Console.Write("Número de partida: ");
                int partida = int.Parse(Console.ReadLine());

                Console.Write("Tipo de operación (venta/alquiler): ");
                string tipo = Console.ReadLine();

                Console.Write("Valor de la operación: ");
                double valor = double.Parse(Console.ReadLine());

				Operacion op = new Operacion(tipo, partida, apellido, valor);
				Sucursal suc = NuevaEmpresa.BuscarSucursalPorCodigo(codigo);
				


                if (suc != null)
                {
                    suc.AtenderCliente(op);
                }
                else
                {
                    Console.WriteLine("Sucursal no encontrada.");
                }

                Console.Write("\n¿Desea registrar otra operación? (si/no): ");
                string opcion = Console.ReadLine().ToLower();
                if (opcion == "no")
                {
                    Seguir1 = false;
                }
            }

            Console.WriteLine("Fin del programa. Gracias por utilizar el sistema.");
        }
	
        // Función recursiva
        public static void Masde20(ArrayList sucursales, int indice)
        {
            if (indice >= sucursales.Count)
                return;

            Sucursal suc = (Sucursal)sucursales[indice];
            if (suc.Operaciones.Count > 20)
            {
                Console.WriteLine("Sucursal " + suc.Codigo + " en " + suc.Localidad + "tiene más de 20 operaciones");
            }

            Masde20(sucursales, indice + 1);
        }
        
        public static bool Multiplo(int A, int B)
        {
            if (A == 0 || B == 0)
            {
                throw new NoCalculoMultiploExpetion();
            }

            return B % A == 0;
        }
    }
}