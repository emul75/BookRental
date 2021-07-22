namespace BookRental.Models
{
    public class UpdatedBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Published { get; set; }
    }
}