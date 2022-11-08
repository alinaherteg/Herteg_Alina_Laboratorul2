using Herteg_Alina_Laboratorul2.Models;

namespace Herteg_Alina_Laboratorul2.Pages.Books
{
    public class BookData
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; }
    }
}
