using System;

namespace ComputerKioskApp.Exceptions
{
    public class OrderPlacementException : Exception
    {
        public OrderPlacementException(string message) : base(message) { }
    }
}
