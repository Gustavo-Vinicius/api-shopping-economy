using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopping_economy.Core.Entities;

namespace shopping_economy.Infrastructure.Persistence.Mappings
{
    public class store_setup_mapping : IEntityTypeConfiguration<StoreSetup>
    {
        public void Configure(EntityTypeBuilder<StoreSetup> entity)
        {
            entity.HasKey(e => e.Id).HasName("store_setup_pkey");

            entity.ToTable("store_setup");

            entity.HasIndex(e => e.Email, "store_setup_email_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.ClosingTime).HasColumnName("closing_time");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Manager)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("manager");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.OpeningHours).HasColumnName("opening_hours");
            entity.Property(e => e.Telephone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("telephone");
        }
    }
}