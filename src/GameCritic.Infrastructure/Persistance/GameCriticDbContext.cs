﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GameCritic.Domain.Entities;
using GameCritic.Domain.Auth;
using GameCritic.Infrastructure.Persistance.Configurations;

namespace GameCritic.Infrastructure.Persistance
{
    public class GameCriticDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public GameCriticDbContext(DbContextOptions<GameCriticDbContext> options) : base(options)
        {

        }

        public DbSet<Award> Awards { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameAward> GameAwards { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AwardConfig());
            builder.ApplyConfiguration(new GameAwardConfig());
            builder.ApplyConfiguration(new GameConfig());
            builder.ApplyConfiguration(new GenreConfig());
            builder.ApplyConfiguration(new PublisherConfig());
            builder.ApplyConfiguration(new ReviewConfig());

            ApplyIdentityMapConfiguration(builder);
        }

        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users","Auth");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", "Auth");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", "Auth");
            modelBuilder.Entity<UserToken>().ToTable("UserRoles", "Auth");
            modelBuilder.Entity<Role>().ToTable("Roles", "Auth");
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", "Auth");
            modelBuilder.Entity<UserRole>().ToTable("UserRole", "Auth");
        }
    }
}