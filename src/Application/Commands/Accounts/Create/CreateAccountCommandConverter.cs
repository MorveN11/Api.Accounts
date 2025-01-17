using Application.Abstractions.Messaging;
using Domain.Accounts;
using SharedKernel.Time;

namespace Application.Commands.Accounts.Create;

internal sealed class CreateAccountCommandConverter(IDateTimeProvider timeProvider)
    : IConverter<CreateAccountCommand, Account>
{
    public Account Convert(CreateAccountCommand from)
    {
        return new Account
        {
            Balance = from.Balance,
            UserId = from.UserId,
            CreatedAt = timeProvider.UtcNow,
        };
    }
}
