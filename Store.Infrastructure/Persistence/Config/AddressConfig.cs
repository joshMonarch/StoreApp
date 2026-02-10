using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence.Config
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();
            
            builder.Property(a => a.UserId)
                .IsRequired();

            builder.Property(a => a.LocationId)
                .IsRequired();
            
            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Region)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Number)
                .IsRequired();

            builder.Property(a => a.Floor)
                .IsRequired();

            builder.Property(a => a.Door)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(a => a.CreatedAt)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(a => a.UpdatedAt)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Location>()
                .WithMany()
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Restrict)
        }
    }
}
