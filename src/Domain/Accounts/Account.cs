using Domain.Users;
using SharedKernel.Domain;

namespace Domain.Accounts;

public sealed class Account : Entity
{
    public decimal Balance { get; set; }

    public required Guid UserId { get; init; }

    public User User { get; init; } = null!;
}
