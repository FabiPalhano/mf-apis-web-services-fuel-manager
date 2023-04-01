using Microsoft.EntityFrameworkCore;

namespace vacina_tracker_v2.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Vacinas> Vacinas { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
    }
}
