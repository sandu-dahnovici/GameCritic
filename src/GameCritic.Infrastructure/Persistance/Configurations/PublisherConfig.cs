using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistance.Configurations
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
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.Country)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Country)
                .HasMaxLength(100);

        }
    }
}
