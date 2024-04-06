using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Models.Configurations
{
    public class GameEntityTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            // Game Entity Configuration

            // Table Name
            builder.ToTable("Games");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(g => g.Description)
                   .HasMaxLength(2500)
                   .IsRequired();

            builder.Property(g => g.Cover)
                   .HasMaxLength(500)
                   .IsRequired();
        }
    }
}
