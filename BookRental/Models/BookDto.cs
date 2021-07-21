using System;

namespace BookRental.Models
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
    }
}