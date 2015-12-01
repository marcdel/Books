namespace Books.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int Isbn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}