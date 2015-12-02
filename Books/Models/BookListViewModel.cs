using System.Collections.Generic;
using System.Linq;

namespace Books.Models
{
    public class BookListViewModel
    {
        public readonly IEnumerable<IGrouping<string, Book>> GroupedBooks;
        public readonly List<string> Letters;

        public BookListViewModel(List<Book> books)
        {
            this.Letters = new List<string> { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
            this.GroupedBooks = books.GroupBy(book => book.Initial);
        }
    }
}