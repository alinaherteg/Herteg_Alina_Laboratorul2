using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Herteg_Alina_Laboratorul2.Data;
using Herteg_Alina_Laboratorul2.Models;

namespace Herteg_Alina_Laboratorul2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Herteg_Alina_Laboratorul2.Data.Herteg_Alina_Laboratorul2Context _context;

        public IndexModel(Herteg_Alina_Laboratorul2.Data.Herteg_Alina_Laboratorul2Context context)
        {
            _context = context;
        }

        public IList<Borrowing> Borrowing { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Borrowing != null)
            {
                Borrowing = await _context.Borrowing
                .Include(b => b.Book)
                .Include(b => b.Member).ToListAsync();
            }
        }
    }
}
