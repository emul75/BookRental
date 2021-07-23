using System;

namespace BookRental.Exceptions
{
    public class BookUnavailableException : Exception
    {
        public BookUnavailableException(string message) : base(message)
        {
        }
    }
}