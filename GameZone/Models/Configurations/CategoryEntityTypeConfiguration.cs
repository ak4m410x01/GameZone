using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameZone.Models.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Category Entity Configuration

            // Table Name
            builder.ToTable("Categories");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }
}
