using Domain.Users;
using Infrastructure.Database.Configurations.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Core;

internal sealed class UserConfiguration : EntityConfiguration<User>
{
    protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Name).HasMaxLength(100);

        builder.Property(u => u.Pic).IsRequired();

        builder.Property(u => u.PicPath).IsRequired();

        builder
            .HasMany(u => u.Accounts)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .IsRequired();
    }
}
