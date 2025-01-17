using Application.Abstractions.Messaging;

namespace Application.Commands.Accounts.Update;

public sealed class UpdateAccountCommand : ICommand
{
    public required Guid AccountId { get; init; }

    public required decimal? Balance { get; init; }
}
