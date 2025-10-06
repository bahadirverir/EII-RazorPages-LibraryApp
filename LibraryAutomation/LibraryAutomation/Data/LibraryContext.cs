using LibraryAutomation.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAutomation.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<OduncAlim> OduncAlimlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kitap>().ToTable("Kitaplar");
            modelBuilder.Entity<Kullanici>().ToTable("Kullanicilar");
            modelBuilder.Entity<OduncAlim>().ToTable("OduncAlimlar");

            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici { KullaniciID = 1, KullaniciAdi = "admin", Sifre = "123", Email = "admin@library.com", Yetki = "Admin" },
                new Kullanici { KullaniciID = 2, KullaniciAdi = "user", Sifre = "123", Email = "user@library.com", Yetki = "Kullanici" }
            );

            modelBuilder.Entity<Kitap>().HasData(
                new Kitap { KitapID = 1, Baslik = "Suç ve Ceza", Yazar = "Fyodor Dostoyevski", YayimYili = 1866, Tur = "Roman", Aciklama = "Raskolnikov'un ahlaki ikilemleri." },
                new Kitap { KitapID = 2, Baslik = "1984", Yazar = "George Orwell", YayimYili = 1949, Tur = "Distopya", Aciklama = "Totaliter bir rejim altında yaşam." },
                new Kitap { KitapID = 3, Baslik = "Sapiens", Yazar = "Yuval Noah Harari", YayimYili = 2011, Tur = "Tarih", Aciklama = "İnsan türünün kısa bir tarihi." },
                new Kitap { KitapID = 4, Baslik = "Hayvan Çiftliği", Yazar = "George Orwell", YayimYili = 1945, Tur = "Alegori", Aciklama = "Bir devrimin ihanete uğraması." }
            );

            modelBuilder.Entity<OduncAlim>().HasData(
                new OduncAlim { OduncID = 1, KitapID = 1, KullaniciID = 2, OduncTarihi = DateTime.Now.AddDays(-15), TeslimTarihi = DateTime.Now.AddDays(-5) },
                new OduncAlim { OduncID = 2, KitapID = 2, KullaniciID = 2, OduncTarihi = DateTime.Now.AddDays(-10), TeslimTarihi = null }
            );
        }
    }
}
