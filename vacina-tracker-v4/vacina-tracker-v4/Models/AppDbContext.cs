using Microsoft.EntityFrameworkCore;

namespace vacina_tracker_v4.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VacinaMembro>()
                .HasKey(c => new { c.VacinaId, c.MembroId });

            builder.Entity<VacinaMembro>()
                .HasOne(c => c.Vacina).WithMany(c => c.Membros)
                .HasForeignKey(c => c.VacinaId);

            builder.Entity<VacinaMembro>()
                .HasOne(c => c.Membro).WithMany(c => c.Vacinas)
                .HasForeignKey(c => c.MembroId);
        }*/

        public DbSet<Vacina> Vacinas { get; set; }
        //public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Membro> Membros { get; set; }
        //public DbSet<VacinaMembro> VacinasMembros { get; set; }
    }
}
