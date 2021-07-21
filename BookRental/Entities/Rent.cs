using System;

namespace BookRental.Entities
{
    public class Rent
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime Rented { get; set; }
        public DateTime Returned { get; set; }
        
    }
}