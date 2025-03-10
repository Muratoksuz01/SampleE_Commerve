using Microsoft.EntityFrameworkCore;

namespace E_ticaret.Models.Sınıflar
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        // DbSet'ler, tablolara karşılık gelir
        public DbSet<Admin> Admins  { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departman> Departmans  { get; set; }
        public DbSet<FaturaKalem> FaturaKalems  { get; set; }
        public DbSet<Faturalar> Faturas  { get; set; }
        public DbSet<Gider> Giders  { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels  { get; set; }
        public DbSet<SatisHareket> SatisHarekets  { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        
     
    }
}
