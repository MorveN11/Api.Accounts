using Application.Abstractions.Messaging;

namespace Application.Commands.Accounts.Delete;

public sealed record DeleteAccountCommand(Guid AccountId) : ICommand;
