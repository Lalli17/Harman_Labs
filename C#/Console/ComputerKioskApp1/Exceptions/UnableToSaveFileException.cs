using System;

namespace ComputerKioskApp.Exceptions
{
    public class UnableToSaveFileException : Exception
    {
        public UnableToSaveFileException()
            : base("Unable to save the file due to an unexpected error.") { }

        public UnableToSaveFileException(string message)
            : base(message) { }

        public UnableToSaveFileException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
