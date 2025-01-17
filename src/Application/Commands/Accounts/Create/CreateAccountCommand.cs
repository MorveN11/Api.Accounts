using Application.Abstractions.Messaging;

namespace Application.Commands.Accounts.Create;

public sealed class CreateAccountCommand : ICommand<Guid>
{
    public required Guid UserId { get; init; }

    public required decimal Balance { get; init; }
}
