using System.ComponentModel.DataAnnotations;

namespace BookRental.Models
{
    public class AddClientDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(15)]
        [Phone]
        public string ContactNumber { get; set; }
    }
}