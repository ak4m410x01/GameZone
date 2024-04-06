using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Models.Configurations
{
    public class DeviceEntityTypeConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            // Game Entity Configuration

            // Table Name
            builder.ToTable("Devices");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(g => g.Icon)
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
