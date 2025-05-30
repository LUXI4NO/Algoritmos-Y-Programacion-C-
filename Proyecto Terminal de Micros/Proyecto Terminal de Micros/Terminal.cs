using System.Collections;
using System;

namespace Practica_Parcial
{
    public class Terminal
    {
        public string Nombre { get; set; }
        public ArrayList Micros { get; set; }


        public Terminal(string nombre)
        {
            Nombre = nombre;
            Micros = new ArrayList(); 
        }

        public bool AgregarMicros(Micros unMicro)
        {
            Micros.Add(unMicro); 
            Console.WriteLine("Micro con codigo " + unMicro.Codigo + " agregado a la terminal " + Nombre);
            return true; 
        }

        public void VentaPasajes()
        {
            Console.WriteLine("\n--- Iniciar Venta de Pasajes en " + Nombre + " ---");
            Console.WriteLine("Escriba 'SALIR' en cualquier momento para finalizar la compra.");

            string inputUsuario;
            int ventasRechazadas = 0; 
            int totalPasajesVendidos = 0; 
            int pasajesLargaDuracionVendidos = 0; 

            do
            {
                Console.WriteLine("\n--- Nuevo Pasaje ---");
                Console.WriteLine("Ingrese DNI del pasajero (o SALIR para terminar):");
                inputUsuario = Console.ReadLine();

                if (inputUsuario.ToLower() == "salir")
                {
                    break; 
                }

                string dniIngresado = inputUsuario;

                Console.WriteLine("Ingrese Apellido del pasajero:");
                string apellidoIngresado = Console.ReadLine();

                Pasajeros nuevoPasajero = new Pasajeros(dniIngresado, apellidoIngresado);

                Console.WriteLine("Ingrese el codigo del micro al que desea viajar:");
                inputUsuario = Console.ReadLine();

                if (inputUsuario.ToLower() == "salir")
                {
                    break; 
                }

                int codigoMicroBuscado;

                if (!int.TryParse(inputUsuario, out codigoMicroBuscado))
                {
                    Console.WriteLine("Codigo de micro no valido. Por favor, ingrese un numero o 'SALIR'.");
                    continue; 
                }

                Micros microEncontrado = null;
                foreach (Micros m in Micros)
                {
                    if (m.Codigo == codigoMicroBuscado)
                    {
                        microEncontrado = m;
                        break; 
                    }
                }

                if (microEncontrado != null) 
                {

                    if (microEncontrado.AgregarPasajero(nuevoPasajero))
                    {
                        totalPasajesVendidos++; 


                        try
                        {
                         
                            string[] partesDuracion = microEncontrado.Duracion.Split(' ');
                            if (partesDuracion.Length > 0)
                            {
                                int duracionEnHoras = int.Parse(partesDuracion[0]);
                                if (duracionEnHoras > 6)
                                {
                                    pasajesLargaDuracionVendidos++;
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Advertencia: No se pudo convertir la duracion del micro " + microEncontrado.Codigo + ". Formato esperado: 'X horas'.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Advertencia: Formato de duracion inesperado para el micro " + microEncontrado.Codigo + ".");
                        }
                    }
                    else
                    {

                        ventasRechazadas++; 
                    }
                }
                else
                {
                    Console.WriteLine("Micro con codigo " + codigoMicroBuscado + " no encontrado en la terminal " + Nombre + ".");
                }

            } while (true); 


            Console.WriteLine("\n--- Resumen de Ventas en " + Nombre + " ---");
            Console.WriteLine("Cantidad de ventas rechazadas por falta de cupo: " + ventasRechazadas);

            if (totalPasajesVendidos > 0)
            {
                double porcentajeLargaDuracion = ((double)pasajesLargaDuracionVendidos / totalPasajesVendidos) * 100;

                Console.WriteLine("Porcentaje de pasajes vendidos en viajes de mas de 6 horas: " + porcentajeLargaDuracion.ToString("0.00") + "%");
            }
            else
            {
                Console.WriteLine("No se vendieron pasajes para calcular el porcentaje de viajes de larga duracion.");
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}