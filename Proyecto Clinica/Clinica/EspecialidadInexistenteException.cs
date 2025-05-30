using System;

namespace Clinica
{
    public class EspecialidadInexistenteException : Exception
    {
        public string EspecialidadBuscada { get; private set; }

        public EspecialidadInexistenteException()
        {
        }
        
        public EspecialidadInexistenteException(string message)
            : base(message)
        {
        }

        public EspecialidadInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public EspecialidadInexistenteException(string message, string especialidadBuscada)
            : base(message)
        {
            EspecialidadBuscada = especialidadBuscada;
        }

        public EspecialidadInexistenteException(string message, string especialidadBuscada, Exception inner)
            : base(message, inner)
        {
            EspecialidadBuscada = especialidadBuscada;
        }
    }
}