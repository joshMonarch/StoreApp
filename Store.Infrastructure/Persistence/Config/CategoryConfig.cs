using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(c => c.CategoryName)
                .IsUnique();

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.UpdatedAt)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();

            builder.HasMany(c => c.Products)
                .WithOne()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
