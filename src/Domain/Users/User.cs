using Domain.Accounts;
using SharedKernel.Domain;

namespace Domain.Users;

public sealed class User : Entity
{
    public string? Name { get; set; }

    public required string Pic { get; set; }

    public required string PicPath { get; set; }

    public IList<Account> Accounts { get; init; } = [];
}
