using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Models.Configurations
{
    public class GameDeviceEntityTypeConfiguration : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            // Game Entity Configuration

            // Table Name
            builder.ToTable("GameDevices");

            // Config Composite Primary Key (GameId, DeviceId)
            builder.HasKey(gd => new { gd.GameId, gd.DeviceId });
        }
    }
}
