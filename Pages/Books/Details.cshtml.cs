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
    public class DetailsModel : PageModel
    {
        private readonly Herteg_Alina_Laboratorul2.Data.Herteg_Alina_Laboratorul2Context _context;

        public DetailsModel(Herteg_Alina_Laboratorul2.Data.Herteg_Alina_Laboratorul2Context context)
        {
            _context = context;
        }

      public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
