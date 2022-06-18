using HollowGlow.blockchain;
using Microsoft.EntityFrameworkCore;

namespace HollowGlow.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<BlockModel> Blocks { get; set; }
        public DbSet<BuildingTypeModel> BuildingTypes { get; set; }
        public DbSet<BuildingGradesModel> BuildingGrades { get; set; }
        public DbSet<BuildingModel> Buildings { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var block = Blockchain.GenerateGenesis();
            block.Id = 1;
            modelBuilder.Entity<BlockModel>().HasData(block);
            modelBuilder.Entity<BuildingTypeModel>().HasData(new[]{
                new BuildingTypeModel() {Id = 1, Name = "Mine" },
                new BuildingTypeModel() {Id = 2, Name = "Townhall" },
                new BuildingTypeModel() {Id = 3, Name = "Watchtower"}
            });

            modelBuilder.Entity<BuildingModel>().HasData(new[]
            {
                new BuildingModel() {Id = 1, Name = "Copper Mine", Description = "First Mine", TypeId = 1, ImagePath = "/images/shop_miner_1.png"},
                new BuildingModel() {Id = 2, Name = "Wooden Townhall", Description = "First Townhall", TypeId = 2, ImagePath = "/images/shop_castle_1.png"},
                new BuildingModel() {Id = 3, Name = "First Watchtower", Description = "First Watchtower", TypeId = 3, ImagePath = "/images/shop_watchtower_1.png"}
            });

            modelBuilder.Entity<BuildingGradesModel>().HasData(new[]
{
                new BuildingGradesModel() {Id = 1, BuildingId = 1, Cost = 100, Lvl = 1, Income = 2, Defense = 0},
                new BuildingGradesModel() {Id = 2, BuildingId = 2, Cost = 500, Lvl = 1, Income = 1, Defense = 1},
                new BuildingGradesModel() {Id = 3, BuildingId = 3, Cost = 300, Lvl = 1, Income = 0, Defense = 5},
            });


            // modelBuilder.Entity<UserModel>()
            //.HasMany(u => u.Grades)
            //.WithMany(g => g.Buyers);

            base.OnModelCreating(modelBuilder);
        }
    }
}
