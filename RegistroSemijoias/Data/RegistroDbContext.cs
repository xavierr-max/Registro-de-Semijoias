using Microsoft.EntityFrameworkCore;
using RegistroDeSemiJoias.Data.Mappings;
using RegistroSemijoias.Models;

namespace RegistroDeSemiJoias.Data
{
    public class RegistroDbContext : DbContext
    {
        public DbSet<Semijoias> SemiJoias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer("Server=localhost,1433;Database=RegistroDeSemiJoias;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SemiJoiaMap());
        }
    }
}
