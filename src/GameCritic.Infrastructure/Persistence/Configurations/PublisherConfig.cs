using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.Configurations
{
    public class PublisherConfig : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.Property(p => p.FoundationYear)
                .HasColumnType("smallint");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(p => p.Games)
                .WithOne(g => g.Publisher)
                .HasForeignKey(g => g.PublisherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Country)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}
