using System.ComponentModel.DataAnnotations;

namespace BookRental.Models
{
    public class AddBookDto
    {
        [Required] [MaxLength(30)] public string Title { get; set; }
        [Required] [MaxLength(30)] public string Author { get; set; }
        [Required] [MaxLength(20)] public string Category { get; set; }
        [Required] public string Published { get; set; }
    }
}