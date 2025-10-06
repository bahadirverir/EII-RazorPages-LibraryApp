using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAutomation.Models
{
    public class OduncAlim
    {
        [Key]
        public int OduncID { get; set; }

        [Required]
        public int KitapID { get; set; }

        [Required]
        public int KullaniciID { get; set; }

        [Required]
        public DateTime OduncTarihi { get; set; }

        public DateTime? TeslimTarihi { get; set; }

        [ForeignKey("KitapID")]
        public Kitap Kitap { get; set; } = null!;

        [ForeignKey("KullaniciID")]
        public Kullanici Kullanici { get; set; } = null!;
    }
}
