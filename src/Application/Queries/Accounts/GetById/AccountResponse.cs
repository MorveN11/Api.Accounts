namespace Application.Queries.Accounts.GetById;

public sealed record AccountResponse
{
    public required Guid Id { get; init; }

    public required decimal Balance { get; init; }

    public required Guid UserId { get; init; }

    public required DateTime CreatedAt { get; init; }

    public required DateTime? UpdatedAt { get; init; }
}
