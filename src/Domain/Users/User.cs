using Domain.Accounts;
using SharedKernel.Domain;

namespace Domain.Users;

public sealed class User : Entity
{
    public required string Name { get; set; }
    public required string LastName { get; set; }

    public required string Email { get; init; }

    public IList<Account> Accounts { get; init; } = [];
}
