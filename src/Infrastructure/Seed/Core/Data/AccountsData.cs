using Domain.Accounts;
using Infrastructure.Seed.Abstractions;
using Infrastructure.Seed.Core.Ids;
using SharedKernel.Time;

namespace Infrastructure.Seed.Core.Data;

internal sealed class AccountsData(IDateTimeProvider timeProvider)
    : SeedEntity<Account>(DbPriority.Two)
{
    protected override IEnumerable<Account> GetData()
    {
        return
        [
            new Account
            {
                Id = AccountsId.One,
                Balance = 1000.00m,
                UserId = UsersId.One,
                CreatedAt = timeProvider.UtcNow,
            },
            new Account
            {
                Id = AccountsId.Two,
                Balance = 1000.00m,
                UserId = UsersId.One,
                CreatedAt = timeProvider.UtcNow,
            },
            new Account
            {
                Id = AccountsId.Three,
                Balance = 1000.00m,
                UserId = UsersId.Two,
                CreatedAt = timeProvider.UtcNow,
            },
            new Account
            {
                Id = AccountsId.Four,
                Balance = 1000.00m,
                UserId = UsersId.Two,
                CreatedAt = timeProvider.UtcNow,
            },
        ];
    }
}
