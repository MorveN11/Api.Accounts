using Application.Abstractions.Messaging;

namespace Application.Commands.Users.Delete;

public sealed record DeleteUserCommand(Guid UserId) : ICommand;
