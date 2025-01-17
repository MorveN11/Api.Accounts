using Application.Abstractions.Messaging;

namespace Application.Commands.Users.Create;

public sealed class CreateUserCommand : ICommand<Guid>
{
    public string? Name { get; init; }

    public required string Pic { get; init; }

    public required string PicPath { get; init; }
}
