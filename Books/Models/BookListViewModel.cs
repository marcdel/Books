using System.Collections.Generic;
using System.Linq;

namespace Books.Models
{
    public class BookListViewModel
    {
        public IEnumerable<IGrouping<string, Book>> GroupedBooks;

        public BookListViewModel(List<Book> books)
        {
            this.GroupedBooks = books.GroupBy(book => book.Initial);
        }
    }
}