using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.Configurations
{
    public class RankingConfig : IEntityTypeConfiguration<Ranking>
    {
        public void Configure(EntityTypeBuilder<Ranking> builder)
        {
            builder.Property(ga => ga.Rank)
                .IsRequired()
                .HasColumnType("smallint");
        }
    }
}
