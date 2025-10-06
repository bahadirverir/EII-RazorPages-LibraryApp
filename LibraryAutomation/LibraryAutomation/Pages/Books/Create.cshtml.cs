using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryAutomation.Data;
using LibraryAutomation.Models;

namespace LibraryAutomation.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly LibraryAutomation.Data.LibraryContext _context;

        public CreateModel(LibraryAutomation.Data.LibraryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Kitap Kitap { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Kitaplar.Add(Kitap);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
