using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.Configurations
{
    public class GameAwardConfig : IEntityTypeConfiguration<GameAward>
    {
        public void Configure(EntityTypeBuilder<GameAward> builder)
        {
            builder.Property(ga => ga.Rank)
                .IsRequired()
                .HasColumnType("smallint");
        }
    }
}
