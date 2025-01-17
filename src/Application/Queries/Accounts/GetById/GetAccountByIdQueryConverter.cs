using Application.Abstractions.Messaging;
using Domain.Accounts;

namespace Application.Queries.Accounts.GetById;

internal sealed class GetAccountByIdQueryConverter : IConverter<Account, AccountResponse>
{
    public AccountResponse Convert(Account from)
    {
        return new AccountResponse
        {
            Id = from.Id,
            UserId = from.UserId,
            Balance = from.Balance,
            CreatedAt = from.CreatedAt,
            UpdatedAt = from.UpdatedAt,
        };
    }
}
