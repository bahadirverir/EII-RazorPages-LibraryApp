using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using LibraryAutomation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryAutomation.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAutomation.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly LibraryContext _context;

        public RegisterModel(LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
            [Display(Name = "Kullanıcı Adı")]
            public string KullaniciAdi { get; set; } = string.Empty;

            [Required(ErrorMessage = "E-posta zorunludur.")]
            [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
            [Display(Name = "E-posta")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Şifre zorunludur.")]
            [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Şifre")]
            public string Sifre { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Display(Name = "Şifreyi Onayla")]
            [Compare("Sifre", ErrorMessage = "Şifre ve onay şifresi eşleşmiyor.")]
            public string ConfirmSifre { get; set; } = string.Empty;
        }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var existingUser = await _context.Kullanicilar.FirstOrDefaultAsync(u => u.KullaniciAdi == Input.KullaniciAdi);
                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Bu kullanıcı adı zaten alınmış.");
                    return Page();
                }

                var user = new Kullanici
                {
                    KullaniciAdi = Input.KullaniciAdi,
                    Email = Input.Email,
                    Sifre = Input.Sifre, // In a real app, hash this password!
                    Yetki = "Kullanici" // Default role
                };

                _context.Kullanicilar.Add(user);
                await _context.SaveChangesAsync();

                // Optionally sign in the user automatically after registration
                // For simplicity, we'll redirect to the login page.
                return RedirectToPage("./Login");
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
