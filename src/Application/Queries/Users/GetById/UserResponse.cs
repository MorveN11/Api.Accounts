namespace Application.Queries.Users.GetById;

public sealed record UserResponse
{
    public required Guid Id { get; init; }

    public required string? Name { get; init; }

    public required string Pic { get; init; }

    public required string PicPath { get; init; }

    public required DateTime CreatedAt { get; init; }

    public required DateTime? UpdatedAt { get; init; }
}
