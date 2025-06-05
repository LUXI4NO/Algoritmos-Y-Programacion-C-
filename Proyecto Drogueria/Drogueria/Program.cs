using System;
using Drogueria;

class Program
{
    static void Main(string[] args)
    {
        GestionDrogueria d = new GestionDrogueria("Droguería Central");

        d.AgregarMedicamento(new Medicamento("Paracetamol", "Paracetamol", "Comprimido", "LabA", 50, 80.5));
        d.AgregarMedicamento(new Medicamento("Ibuprofeno", "Ibuprofeno", "Jarabe", "LabB", 40, 120.0));
        d.AgregarMedicamento(new Medicamento("Amoxicilina", "Amoxicilina", "Cápsula", "LabC", 30, 95.0));
        d.AgregarMedicamento(new Medicamento("Diclofenaco", "Diclofenaco", "Gel", "LabD", 25, 75.25));
        d.AgregarMedicamento(new Medicamento("Omeprazol", "Omeprazol", "Cápsula", "LabE", 60, 110.0));
        d.AgregarMedicamento(new Medicamento("Omeprazol", "Omeprazol", "Cápsula", "Pfizer", 60, 110.0));

        Console.WriteLine("Medicamentos antes de ordenar por precio:");
        d.MostrarMedicamentos();

        d.ordenaXprecio();

        Console.WriteLine("\nMedicamentos después de ordenar por precio:");
        d.MostrarMedicamentos();
        
        for (int i = 0; i < 3; i++)
        {
            try
            {
                Console.WriteLine("\n--- NUEVO PEDIDO ---");
                Console.Write("Nombre del medicamento: ");
                string nombre = Console.ReadLine();

                Console.Write("Presentación: ");
                string presentacion = Console.ReadLine();

                Console.Write("Nombre de la farmacia: ");
                string farmacia = Console.ReadLine();

                Console.Write("Cantidad pedida: ");
                int cantidad = int.Parse(Console.ReadLine());

                Pedido nuevoPedido = new Pedido(nombre, presentacion, farmacia, cantidad);
                d.RecepcionPedidos(nuevoPedido);

                Console.WriteLine("Pedido aceptado correctamente.");
            }
            catch (StockInsuficienteException ex)
            {
                Console.WriteLine("ERROR (stock insuficiente): " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

        Console.WriteLine("\nPorcentaje de pedidos rechazados: " + d.PorcentajeRechazos().ToString("F2") + "%");
		d.PedidosRecibidos();

        Console.ReadKey(); 
    }
}
