using Application.Abstractions.Messaging;
using Domain.Users;

namespace Application.Queries.Users.GetById;

internal sealed class GetUserByIdQueryConverter : IConverter<User, UserResponse>
{
    public UserResponse Convert(User from)
    {
        return new UserResponse
        {
            Id = from.Id,
            Name = from.Name,
            Pic = from.Pic,
            PicPath = from.PicPath,
            CreatedAt = from.CreatedAt,
            UpdatedAt = from.UpdatedAt,
        };
    }
}
