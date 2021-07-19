using System;

namespace BookRental.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string ClientName { get; set; }
        public DateTime Published { get; set; }
        public DateTime Rented { get; set; }
        public DateTime Returned { get; set; }
        public bool RentalStatus { get; set; }
        
    }
}