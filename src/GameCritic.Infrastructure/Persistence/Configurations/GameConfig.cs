using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.Configurations
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(g => g.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.ReleaseDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(g => g.RowVersion)
                .IsRowVersion();

            builder.Property(g => g.Score)
                .HasPrecision(2);

            builder.Property(g => g.Summary)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(g => g.Price)
                .HasColumnType("money")
                .HasPrecision(3);

            builder.HasMany(g => g.Reviews)
                .WithOne(r => r.Game)
                .HasForeignKey(r => r.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(g => g.GameGenres)
                .WithOne(gg => gg.Game)
                .HasForeignKey(gg => gg.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(g => g.GameAwards)
                .WithOne(ga => ga.Game)
                .HasForeignKey(ga => ga.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.Publisher)
                .WithMany(p => p.Games)
                .HasForeignKey(g => g.PublisherId);
        }
    }
}
