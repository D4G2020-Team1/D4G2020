using BO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DesignDbContext : DbContext
    {
        public static IConfiguration Configuration;

        public DbSet<Score> Scores { get; set; }
        public DbSet<Commune> Communes { get; set; }
        public DbSet<Historique> Historiques { get; set; }

        public DesignDbContext()
        {

        }

        public DesignDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Configuration.GetConnectionString("DesignDb"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Score>()
                .HasOne(o => o.Commune)
                .WithMany(o => o.Scores)
                .HasForeignKey(o => o.CodeCommune)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
