using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Herteg_Alina_Laboratorul2.Data;
using Herteg_Alina_Laboratorul2.Models;

namespace Herteg_Alina_Laboratorul2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Herteg_Alina_Laboratorul2.Data.Herteg_Alina_Laboratorul2Context _context;

        public IndexModel(Herteg_Alina_Laboratorul2.Data.Herteg_Alina_Laboratorul2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }

        public string CurrentFilter { get; set; }

        public string BookCategories { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder)
        {
            BookD = new BookData();
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
     

        BookD.Books = await _context.Book
                .Include(a => a.Author)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "title_desc":
                    BookD.Books = BookD.Books.OrderByDescending(s =>
                    s.Title);
                    break;
                case "author_desc":
                    BookD.Books = BookD.Books.OrderByDescending(s =>
                    s.Author.FullName);
                    break;
            }
        }
    }
}
