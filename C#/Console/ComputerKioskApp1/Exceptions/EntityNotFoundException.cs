using System;

namespace ComputerKioskApp.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entity, int id)
            : base($"{entity} with ID {id} was not found.") { }

        public EntityNotFoundException(string message)
            : base(message) { }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
