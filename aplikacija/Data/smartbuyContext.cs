using aplikacija.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace aplikacija.Data
{
    public class smartbuyContext : IdentityDbContext<ApplicationUser>
    {
        public smartbuyContext(DbContextOptions<smartbuyContext> options) : base(options)
        {
        }

        public DbSet<Artikel> Artikli { get; set; }
        public DbSet<Ocena> Ocene { get; set; }
        public DbSet<Oseba> Osebe { get; set; }

        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Narocilo> Narocila { get; set; }
        public DbSet<Naslov> Naslovi { get; set; }

        public DbSet<Postavka> Postavke { get; set; }
        public DbSet<Proizvajalec> Proizvajalci { get; set; }
        public DbSet<Racun> Racuni { get; set; }

        public DbSet<Status> Statusi { get; set; }
        public DbSet<TipPrevzema> TipiPrevzema { get; set; }
        public DbSet<VrstaPlacila> VrstePlacila { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Artikel>().ToTable("Artikel");
            modelBuilder.Entity<Ocena>().ToTable("Ocena");
            modelBuilder.Entity<Oseba>().ToTable("Oseba");
            modelBuilder.Entity<Kategorija>().ToTable("Kategorija");
            //modelBuilder.Entity<Narocilo>().ToTable("Narocilo");
            modelBuilder.Entity<Naslov>().ToTable("Naslov");
            //modelBuilder.Entity<Postavka>().ToTable("Postavka");
            modelBuilder.Entity<Proizvajalec>().ToTable("Proizvajalec");
            modelBuilder.Entity<Racun>().ToTable("Racun");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<TipPrevzema>().ToTable("TipPrevzema");
            modelBuilder.Entity<VrstaPlacila>().ToTable("VrstaPlacila");
            modelBuilder.Entity<Postavka>().ToTable("Postavka")
            .HasKey(c => new { c.ArtikelID, c.NarociloID });
            modelBuilder.Entity<ArtikelVKosarici>().ToTable("ArtikelVKosarici")
            .HasKey(c => new { c.ArtikelID, c.OsebaID });

            modelBuilder.Entity<Narocilo>().ToTable("Narocilo")
            .HasOne(c => c.Oseba)
            .WithMany()
            .HasForeignKey(c => c.OsebaID)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}