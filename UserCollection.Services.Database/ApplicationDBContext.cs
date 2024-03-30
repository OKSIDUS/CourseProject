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

        public DbSet<TagEntity> Tags { get; set; }

        public DbSet<ItemsTagsEntity> ItemsTags { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

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

            modelBuilder.Entity<ItemsTagsEntity>()
        .HasKey(it => new { it.ItemId, it.TagId });

            modelBuilder.Entity<ItemsTagsEntity>()
                .HasOne(it => it.Item)
                .WithMany(i => i.ItemsTags)
                .HasForeignKey(it => it.ItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemsTagsEntity>()
                .HasOne(it => it.Tag)
                .WithMany(t => t.ItemsTags)
                .HasForeignKey(it => it.TagId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CommentEntity>()
                .HasOne(c => c.Item)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
