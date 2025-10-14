using Microsoft.EntityFrameworkCore;
using EasyGames.Domain.Catalog;

namespace EasyGames.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        //options come from Program.cs DI
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // this maps Product entity to a "Products" table.
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //simple config; keep names easy to read for marking.
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(p => p.Id);
                e.Property(p => p.Name).HasMaxLength(120).IsRequired();
                e.Property(p => p.Cost).HasColumnType("decimal(18,2)");
                e.Property(p => p.Price).HasColumnType("decimal(18,2)");
                // add indexes or unique rules later if needed
            });
        }
    }
}


