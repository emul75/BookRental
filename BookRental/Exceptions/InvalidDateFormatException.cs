using System;

namespace BookRental.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException(string message) : base(message)
        {
        }
    }
}