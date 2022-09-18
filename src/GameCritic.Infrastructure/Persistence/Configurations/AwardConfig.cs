using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.Configurations
{
    public class AwardConfig : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.Property(a => a.Title)
                .HasMaxLength(50);

            builder.Property(a => a.Year)
                .HasColumnType("smallint");

            builder.HasMany(a => a.GameAwards)
                .WithOne(ga => ga.Award)
                .HasForeignKey(ga => ga.AwardId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
