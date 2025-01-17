using Application.Abstractions.Messaging;

namespace Application.Commands.Accounts.Create;

public sealed class CreateAccountCommand : ICommand<Guid>
{
    public decimal Balance { get; init; }

    public required Guid UserId { get; init; }
}
