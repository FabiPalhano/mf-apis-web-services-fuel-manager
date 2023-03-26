using Microsoft.EntityFrameworkCore;

namespace vacina_tracker_v1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Vacina> Vacina { get; set; }  
        public DbSet<Responsavel> Responsavel { get; set; }
    }
}
