using System.ComponentModel.DataAnnotations;

namespace LibraryAutomation.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }

        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Sifre { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Yetki { get; set; } = null!;

        public ICollection<OduncAlim> OduncAlimlar { get; set; } = new List<OduncAlim>();
    }
}
