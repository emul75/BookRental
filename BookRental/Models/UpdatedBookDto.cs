using System.ComponentModel.DataAnnotations;

namespace BookRental.Models
{
    public class UpdatedBookDto
    {
        [Required]
        public int Id { get; set; }        
        [MaxLength(30)]
        public string Title { get; set; } 
        [MaxLength(30)]
        public string Author { get; set; } 
        [MaxLength(20)]
        public string Category { get; set; }
        public string Published { get; set; }
    }
}