using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;
using GameCritic.Domain.Auth;

namespace GameCritic.Infrastructure.Persistence.Configurations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(r => r.CreationDate)
                .HasColumnType("date");

            builder.Property(r => r.Mark)
                .IsRequired();

            builder.Property(r => r.Comment)
                .HasMaxLength(1000);
        }
    }
}
