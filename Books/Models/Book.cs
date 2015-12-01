using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int Isbn { get; set; }

        [NotMapped]
        public string Initial
        {
            get
            {
                return string.IsNullOrEmpty(this.Title) ? string.Empty : this.Title[0].ToString();
            }
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}