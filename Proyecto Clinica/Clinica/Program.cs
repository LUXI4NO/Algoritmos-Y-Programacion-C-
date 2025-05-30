using System;
using System.Collections; // Considera cambiar a System.Collections.Generic para List<T>

namespace Clinica
{
    class Program
    {
        public static void Main(string[] args)
        {
            CentroClinico MiCentroClinico = new CentroClinico("San Isidro");
            Console.WriteLine("Bienvenido al centro clínico: " + MiCentroClinico.Nombre);

            Console.WriteLine("\n--- Agregando datos de ejemplo ---");
            MiCentroClinico.AgregarMedico(new Medicos("Luciano", "100", "Pediatra"));
            MiCentroClinico.AgregarMedico(new Medicos("Eliana", "200", "Cirujana"));
            MiCentroClinico.AgregarMedico(new Medicos("Carmen", "300", "Obstetra"));

            MiCentroClinico.AgregarPacientes(new Pacientes("Luciano", "Alvarez", 100, "44585917", "OSECAC", "Cancer"));
            MiCentroClinico.AgregarPacientes(new Pacientes("Eliana", "Vazquez", 200, "48000000", "OSDE", "Loca")); 
            MiCentroClinico.AgregarPacientes(new Pacientes("Antonio", "Alvarez", 300, "25581977", "UOCRA", "Ni idea"));
            MiCentroClinico.AgregarPacientes(new Pacientes("Maria", "Gonzalez", 400, "30123456", "OSDE", "Control")); 


            bool ContinuarAplicacion = true;
            int intentosDeAtencionTotales = 0;
            int atencionesFallidasPorEspecialidad = 0;

            while (ContinuarAplicacion)
            {
                Console.WriteLine("\n--- Menú Principal Clínica San Isidro ---");
                Console.WriteLine("1. Ingresar Datos de un nuevo Médico.");
                Console.WriteLine("2. Ingresar Datos de un nuevo Paciente.");
                Console.WriteLine("3. Atencion Al Paciente.");
                Console.WriteLine("4. Salir y Mostrar Informe Final."); 
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("\n--- Datos del nuevo médico ---");
                        Console.Write("Ingrese el nombre del médico: ");
                        string medicoNombre = Console.ReadLine();
                        Console.Write("Ingrese el legajo del médico: ");
                        string medicoLegajo = Console.ReadLine();
                        Console.Write("Ingrese la especialidad del médico: ");
                        string medicoEspecialidad = Console.ReadLine();

                        Medicos nuevoMedico = new Medicos(medicoNombre, medicoLegajo, medicoEspecialidad);
                        MiCentroClinico.AgregarMedico(nuevoMedico);
                        break;

                    case "2":
                        Console.WriteLine("\n--- Datos del nuevo paciente ---");
                        Console.Write("Ingrese el nombre del paciente: ");
                        string pacienteNombre = Console.ReadLine();
                        Console.Write("Ingrese el apellido del paciente: ");
                        string pacienteApellido = Console.ReadLine();
                        Console.Write("Ingrese el historial clínico del paciente (número): ");
                        int historialPaciente;
                        while (!int.TryParse(Console.ReadLine(), out historialPaciente))
                        {
                            Console.WriteLine("Entrada inválida. Por favor, ingrese un número para el historial clínico: ");
                        }

                        Console.Write("Ingrese el DNI del paciente: ");
                        string dniPaciente = Console.ReadLine();
                        Console.Write("Ingrese la obra social del paciente: ");
                        string obraSocialPaciente = Console.ReadLine();
                        Console.Write("Ingrese el diagnóstico del paciente: ");
                        string diagnosticoPaciente = Console.ReadLine();

                        Pacientes nuevoPaciente = new Pacientes(pacienteNombre, pacienteApellido, historialPaciente, dniPaciente, obraSocialPaciente, diagnosticoPaciente);
                        MiCentroClinico.AgregarPacientes(nuevoPaciente);
                        break;

                    case "3":
                        Console.WriteLine("\n--- Atención al Paciente ---");
                        intentosDeAtencionTotales++;

                        Console.Write("Diga qué especialidad desea consultar: ");
                        string especialidadParaElCliente = Console.ReadLine();

                        Console.Write("Diga su DNI para poder atenderlo: ");
                        string dniParaAtenderlo = Console.ReadLine();

                        try
                        {
                            MiCentroClinico.AtencionAlPaciente(especialidadParaElCliente, dniParaAtenderlo);
                        }
                        catch (EspecialidadInexistenteException ex)
                        {
                            atencionesFallidasPorEspecialidad++; 
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("ERROR: " + ex.Message);
                            Console.WriteLine("Especialidad buscada: " + ex.EspecialidadBuscada);
                            Console.WriteLine("Por favor, ingrese una especialidad válida.");
                            Console.WriteLine("--------------------------------------------------");
                        }
                        catch (PacienteNoEncontradoException ex)
                        {
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("ERROR: " + ex.Message);
                            Console.WriteLine("DNI buscado: " + ex.DniBuscado);
                            Console.WriteLine("Por favor, verifique el DNI ingresado.");
                            Console.WriteLine("--------------------------------------------------");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("Ocurrió un error inesperado en la atención: " + ex.Message);
                            Console.WriteLine("--------------------------------------------------");
                        }
                        break;

                    case "4":
                        ContinuarAplicacion = false;
                        Console.WriteLine("\n--- Finalizando Simulación ---");
                        MiCentroClinico.GenerarReporteFinal(intentosDeAtencionTotales, atencionesFallidasPorEspecialidad);
                        Console.WriteLine("\nSaliendo de la aplicación. ¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                        break;
                }
            }

            Console.Write("\nPresione cualquier tecla para salir . . . ");
            Console.ReadKey(true);
        }
    }
}