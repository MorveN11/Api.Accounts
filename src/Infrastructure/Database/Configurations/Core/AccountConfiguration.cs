using Domain.Accounts;
using Infrastructure.Database.Configurations.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations.Core;

internal sealed class AccountConfiguration : EntityConfiguration<Account>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Account> builder)
    {
        builder.Property(a => a.Balance).IsRequired().HasColumnType("decimal(18,2)");

        builder.Property(a => a.AccountNumber).IsRequired().HasMaxLength(255);
        builder.HasIndex(a => a.AccountNumber).IsUnique();
    }
}
