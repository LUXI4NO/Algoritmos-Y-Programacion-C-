using System;
using System.Collections;

namespace Drogueria
{
    public class GestionDrogueria
    {
        public string Nombre { get; set; }
        public ArrayList medicamentos;
        public ArrayList pedidos;
        private int PedidosTotales = 0;
        private int PedidosRechazados = 0;

        public GestionDrogueria(string nombre)
        {
            Nombre = nombre;
            medicamentos = new ArrayList();
            pedidos = new ArrayList();
        }

        public void AgregarMedicamento(Medicamento medicamento)
        {
            medicamentos.Add(medicamento);
        }

        public void AgregarPedido(Pedido pedido)
        {
            pedidos.Add(pedido);
        }

        public void ordenaXprecio()
        {
            int n = medicamentos.Count;
            int i = 0;
            bool ordenado = false;

            while ((i < (n - 1)) && (ordenado == false))
            {
                ordenado = true;

                for (int j = 0; j < (n - 1 - i); j++)
                {
                    Medicamento m1 = (Medicamento)medicamentos[j];
                    Medicamento m2 = (Medicamento)medicamentos[j + 1];

                    if (m1.Precio > m2.Precio)
                    {
                        ordenado = false;

                        medicamentos[j] = m2;
                        medicamentos[j + 1] = m1;
                    }
                }

                i++;
            }
        }

        public void MostrarMedicamentos()
        {
            if (medicamentos.Count == 0)
            {
                Console.WriteLine("No hay medicamentos para mostrar.");
                return;
            }

            Console.WriteLine("\n--- Lista de Medicamentos ---");
            foreach (object item in medicamentos)
            {
                Medicamento m = item as Medicamento;
                if (m != null)
                {
                    Console.WriteLine("Nombre: " + m.Nombre + " | Precio: $" + m.Precio.ToString("F2"));
                }
            }
        }
        
        
		public void RecepcionPedidos(Pedido NuevoPedido)
		{
		    PedidosTotales++;
		
		    foreach (Medicamento m in medicamentos)
		    {
		        if (m.Nombre == NuevoPedido.NombreMedicamento && m.Presentacion == NuevoPedido.Presentacion)
		        {
		            if (m.Stock >= NuevoPedido.CantidadEnvases)
		            {
		                m.Stock -= NuevoPedido.CantidadEnvases;
		                pedidos.Add(NuevoPedido);
		                return;
		            }
		            else
		            {
		                PedidosRechazados++; 
		                throw new StockInsuficienteException("No hay stock suficiente. Stock actual: " + m.Stock);
		            }
		        }
		    }
		
		    PedidosRechazados++; 
		    throw new Exception("El medicamento solicitado no existe en la droguería.");
		}

        
		public double PorcentajeRechazos()
		{
		    if (PedidosTotales == 0) return 0;
		    return (double)PedidosRechazados / PedidosTotales * 100;
		}
		
		public void PedidosRecibidos()
		{
		    Console.WriteLine("\nTotal de pedidos recibidos: " + pedidos.Count);
		
		    ArrayList pfizer = new ArrayList();
		
		    foreach (Medicamento m in medicamentos)
		    {
		        if (m.Laboratorio.ToLower() == "pfizer")
		        {
		            pfizer.Add(m);
		        }
		    }
		
		    if (pfizer.Count == 0)
		    {
		        Console.WriteLine("No hay medicamentos del laboratorio Pfizer.");
		        return;
		    }
		
		    int n = pfizer.Count;
		    bool ordenado = false;
		    int i = 0;
		
		    while (i < n - 1 && ordenado == false)
		    {
		        ordenado = true;
		
		        for (int j = 0; j < n - 1 - i; j++)
		        {
		            Medicamento m1 = (Medicamento)pfizer[j];
		            Medicamento m2 = (Medicamento)pfizer[j + 1];
		
		            if (m1.Precio > m2.Precio)
		            {
		                pfizer[j] = m2;
		                pfizer[j + 1] = m1;
		                ordenado = false;
		            }
		        }
		
		        i++;
		    }
		
		    Console.WriteLine("\n--- Medicamentos de Pfizer ordenados por precio ---");
		    foreach (Medicamento m in pfizer)
		    {
		        Console.WriteLine("Nombre: " + m.Nombre + " | Precio: " + m.Precio.ToString("F2"));
		    }
		}
    }
}
