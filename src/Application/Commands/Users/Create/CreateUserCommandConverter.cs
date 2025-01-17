using Application.Abstractions.Messaging;
using Domain.Users;
using SharedKernel.Time;

namespace Application.Commands.Users.Create;

internal sealed class CreateUserCommandConverter(IDateTimeProvider timeProvider)
    : IConverter<CreateUserCommand, User>
{
    public User Convert(CreateUserCommand from)
    {
        return new User
        {
            Name = from.Name,
            Pic = from.Pic,
            PicPath = from.PicPath,
            CreatedAt = timeProvider.UtcNow,
        };
    }
}
