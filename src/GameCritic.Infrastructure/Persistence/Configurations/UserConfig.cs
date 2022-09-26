using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameCritic.Domain.Entities;
using GameCritic.Domain.Auth;

namespace GameCritic.Infrastructure.Persistence.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(u => u.RegisterDateTime)
                .IsRequired();
        }
    }
}
