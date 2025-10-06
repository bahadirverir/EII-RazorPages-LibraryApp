using System.ComponentModel.DataAnnotations;

namespace LibraryAutomation.Models
{
    public class Kitap
    {
        [Key]
        public int KitapID { get; set; }

        [Required]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(50)]
        public string Yazar { get; set; }

        public int YayimYili { get; set; }

        [StringLength(50)]
        public string Tur { get; set; }

        public string? Aciklama { get; set; }

        public ICollection<OduncAlim> OduncAlimlar { get; set; } = new List<OduncAlim>();
    }
}
