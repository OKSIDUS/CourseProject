using Microsoft.EntityFrameworkCore;
using UserCollection.Services.Database.Entities;

namespace UserCollection.Services.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<CollectionEntity> Collections { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<ItemEntity> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionEntity>()
                .HasOne(c => c.Category)
                .WithMany(cc => cc.UserCollections)
                .HasForeignKey(c => c.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemEntity>()
                .HasOne(i => i.Collection)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CollectionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
