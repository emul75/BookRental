using System;
using System.ComponentModel.DataAnnotations;

namespace BookRental.Models
{
    public class RentOrReturnBookDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
    }
}