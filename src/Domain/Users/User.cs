using Domain.Accounts;
using SharedKernel.Domain;

namespace Domain.Users;

public sealed class User : Entity
{
    public string? Name { get; set; }

    public required string Pic { get; init; }

    public required string PicPath { get; init; }

    public IList<Account> Accounts { get; init; } = [];
}
