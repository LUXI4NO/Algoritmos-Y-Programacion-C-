using System.Collections;
using System;

namespace Clinica
{
    public class CentroClinico
    {
        public string Nombre { get; set; }
        public ArrayList ListaMedicos { get; set; }
        public ArrayList ListaPacientes { get; set; }

        public CentroClinico(string nombre)
        {
            Nombre = nombre;
            ListaMedicos = new ArrayList(); 
            ListaPacientes = new ArrayList(); 
        }

        public bool AgregarMedico(Medicos medico)
        {
            ListaMedicos.Add(medico);
            Console.WriteLine("El médico llamado " + medico.Nombre + " con especialidad en: " + medico.Especialidad + " fue agregado correctamente.");
            return true;
        }

        public bool AgregarPacientes(Pacientes paciente)
        {
            ListaPacientes.Add(paciente);
            Console.WriteLine("El paciente " + paciente.Nombre + " " + paciente.Apellido + " con DNI: " + paciente.DNI + " fue agregado correctamente.");
            return true;
        }

        public bool AtencionAlPaciente(string especialidadDeseada, string dniPaciente)
        {
            Medicos medicoEncontrado = null;
            Pacientes pacienteEncontrado = null;

            foreach (Medicos m in ListaMedicos) 
            {
                if (m.Especialidad.Equals(especialidadDeseada, StringComparison.OrdinalIgnoreCase)) 
                {
                    medicoEncontrado = m;
                    break;
                }
            }

            if (medicoEncontrado == null)
            {
                throw new EspecialidadInexistenteException("No se encontró ningún médico disponible con la especialidad indicada.", especialidadDeseada);
            }

            foreach (Pacientes p in ListaPacientes) 
            {
                if (p.DNI == dniPaciente)
                {
                    pacienteEncontrado = p;
                    break;
                }
            }

            if (pacienteEncontrado == null)
            {
                throw new PacienteNoEncontradoException("No se encontró ningún paciente registrado con el DNI indicado.", dniPaciente);
            }

            Console.WriteLine("Atendiendo al paciente " + pacienteEncontrado.Nombre + " " + pacienteEncontrado.Apellido + " (" + pacienteEncontrado.DNI + ")");
            Console.WriteLine("Con el médico " + medicoEncontrado.Nombre + " de especialidad " + medicoEncontrado.Especialidad + ".");

            Console.Write("Por favor, ingrese el nuevo diagnóstico para el paciente: ");
            string nuevoDiagnostico = Console.ReadLine();

            pacienteEncontrado.Diagnostico = nuevoDiagnostico;
            Console.WriteLine("Diagnóstico del paciente " + pacienteEncontrado.Nombre + " actualizado correctamente a: '" + pacienteEncontrado.Diagnostico + "'.");
            return true;
        }

        public void GenerarReporteFinal(int totalIntentosAtencion, int conteoEspecialidadNoEncontrada)
        {
            Console.WriteLine("\n--- Informe Final de la Simulación ---");

            Console.WriteLine("\n[Reporte de Atenciones]");
            double porcentajeFallido = 0;
            if (totalIntentosAtencion > 0)
            {
                porcentajeFallido = ((double)conteoEspecialidadNoEncontrada / totalIntentosAtencion) * 100;
            }
            Console.WriteLine("Total de intentos de atención: " + totalIntentosAtencion);
            Console.WriteLine("Atenciones fallidas por especialidad no existente: " + conteoEspecialidadNoEncontrada);
            Console.WriteLine("Porcentaje de atenciones fallidas por especialidad no existente: " + porcentajeFallido.ToString("F2") + "%");

            Console.WriteLine("\n[Pacientes con Obra Social OSDE]");
            bool osdeEncontrado = false;
            
            foreach (Pacientes paciente in ListaPacientes)
            {
                if (paciente.Obra_Social.Equals("OSDE", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("- Nombre: " + paciente.Nombre + " " + paciente.Apellido + ", DNI: " + paciente.DNI + ", Historial: " + paciente.Historial_Clinico);
                    osdeEncontrado = true;
                }
            }

            if (!osdeEncontrado)
            {
                Console.WriteLine("No se encontraron pacientes con la obra social OSDE.");
            }
            Console.WriteLine("------------------------------------");
        }
    }
}