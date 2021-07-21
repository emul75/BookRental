namespace BookRental.Models
{
    public class BookForListDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string DatePublished { get; set; }
        public bool Available { get; set; }
    }
}