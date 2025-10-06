using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryAutomation.Data;
using LibraryAutomation.Models;

namespace LibraryAutomation.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly LibraryAutomation.Data.LibraryContext _context;

        public IndexModel(LibraryAutomation.Data.LibraryContext context)
        {
            _context = context;
        }

        public IList<Kitap> Kitap { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Kitap = await _context.Kitaplar.ToListAsync();
        }
    }
}
