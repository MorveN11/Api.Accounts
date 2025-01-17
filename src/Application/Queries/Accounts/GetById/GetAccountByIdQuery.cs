using Application.Abstractions.Messaging;

namespace Application.Queries.Accounts.GetById;

public sealed record GetAccountByIdQuery(Guid AccountId) : IQuery<AccountResponse>;
