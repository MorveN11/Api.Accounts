using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using SharedKernel.Results;
using SharedKernel.Time;

namespace Application.Commands.Users.Create;

internal sealed class CreateUserCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider timeProvider
) : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken
    )
    {
        User user = new CreateUserCommandConverter(timeProvider).Convert(request);

        context.Users.Add(user);

        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
