using Application.Abstractions.Messaging;

namespace Application.Commands.Users.Update;

public sealed class UpdateUserCommand : ICommand
{
    public required Guid UserId { get; init; }

    public required string? Name { get; init; }
}
