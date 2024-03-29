﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;

namespace GameCritic.Infrastructure.Persistence.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(g => g.Description)
                .HasMaxLength(2000);

            builder.HasMany(g => g.GameGenres)
                .WithOne(gg => gg.Genre)
                .HasForeignKey(gg => gg.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
