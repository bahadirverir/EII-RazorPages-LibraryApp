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
    public class DeleteModel : PageModel
    {
        private readonly LibraryAutomation.Data.LibraryContext _context;

        public DeleteModel(LibraryAutomation.Data.LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kitap Kitap { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar.FirstOrDefaultAsync(m => m.KitapID == id);

            if (kitap == null)
            {
                return NotFound();
            }
            else
            {
                Kitap = kitap;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap != null)
            {
                Kitap = kitap;
                _context.Kitaplar.Remove(Kitap);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
