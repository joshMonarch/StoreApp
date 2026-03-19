using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence.SQLServer.Config
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Locations");

            builder.HasIndex(l => l.Id);

            builder.Property(l => l.Id)
                .IsRequired();

            builder.Property(l => l.LocationType)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(l => l.LocationType)
                .IsUnique();

            builder.Property(l => l.CreatedAt)
                .IsRequired();

            builder.Property(l => l.UpdatedAt)
                .IsRequired();

            builder.HasMany(l => l.Addresses)
                .WithOne()
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
