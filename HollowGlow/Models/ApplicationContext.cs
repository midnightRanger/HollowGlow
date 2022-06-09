using Microsoft.EntityFrameworkCore;

namespace HollowGlow.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UpgradesModel> Upgrades { get; set; }
        public DbSet<UpgradesShopModel> UpgradesShop { get; set; }
        public DbSet<ItemModel> ItemsModel { get; set;  }
        public DbSet<BlockModel> BlocksModel { get; set; }
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Ad>()
        //   .HasOne(p => p.user)
        //   .WithMany(t => t.Ads)
        //   .OnDelete(DeleteBehavior.Cascade);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
