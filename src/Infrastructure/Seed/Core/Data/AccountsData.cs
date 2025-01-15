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
                AccountNumber = "123456",
                Balance = 1000.00m,
                UserId = UsersId.One,
                CreatedAt = timeProvider.UtcNow,
            },
            new Account
            {
                Id = AccountsId.Two,
                AccountNumber = "234567",
                Balance = 1000.00m,
                UserId = UsersId.One,
                CreatedAt = timeProvider.UtcNow,
            },
            new Account
            {
                Id = AccountsId.Three,
                AccountNumber = "345678",
                Balance = 1000.00m,
                UserId = UsersId.Two,
                CreatedAt = timeProvider.UtcNow,
            },
            new Account
            {
                Id = AccountsId.Four,
                AccountNumber = "456789",
                Balance = 1000.00m,
                UserId = UsersId.Two,
                CreatedAt = timeProvider.UtcNow,
            },
        ];
    }
}
