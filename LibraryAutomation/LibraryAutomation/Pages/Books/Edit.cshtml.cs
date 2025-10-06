using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryAutomation.Data;
using LibraryAutomation.Models;

namespace LibraryAutomation.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly LibraryAutomation.Data.LibraryContext _context;

        public EditModel(LibraryAutomation.Data.LibraryContext context)
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

            var kitap =  await _context.Kitaplar.FirstOrDefaultAsync(m => m.KitapID == id);
            if (kitap == null)
            {
                return NotFound();
            }
            Kitap = kitap;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kitap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KitapExists(Kitap.KitapID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KitapExists(int id)
        {
            return _context.Kitaplar.Any(e => e.KitapID == id);
        }
    }
}
