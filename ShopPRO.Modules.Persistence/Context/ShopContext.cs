using Microsoft.EntityFrameworkCore;
using ShopPRO.Modules.Domain.Entities;

namespace ShopPRO.Modules.Persistence.Context
{
    public class ShopContext : DbContext
    {

        #region"Constructor"
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        #endregion

        #region"Db Sets"
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Tests> Tests { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .ToTable("Orders", "Sales");
            modelBuilder.Entity<Scores>()
                .ToTable("Scores", "Stats");
            modelBuilder.Entity<Tests>()
                .ToTable("Tests", "Stats");
        }
    }
}
