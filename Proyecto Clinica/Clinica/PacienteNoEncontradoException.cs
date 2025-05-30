using System;

namespace Clinica
{
    public class PacienteNoEncontradoException : Exception
    {
        public string DniBuscado { get; private set; }
        
        public PacienteNoEncontradoException()
        {
        }

        public PacienteNoEncontradoException(string message)
            : base(message)
        {
        }

        public PacienteNoEncontradoException(string message, Exception inner)
            : base(message, inner)
        {
        }
        
        public PacienteNoEncontradoException(string message, string dniBuscado)
            : base(message)
        {
            DniBuscado = dniBuscado;
        }

        public PacienteNoEncontradoException(string message, string dniBuscado, Exception inner)
            : base(message, inner)
        {
            DniBuscado = dniBuscado;
        }
    }
}