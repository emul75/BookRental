using System;

namespace BookRental.Exceptions
{
    public class NumberIsInUseException : Exception
    {
        public NumberIsInUseException(string message) : base(message)
        {
        }
    }
}