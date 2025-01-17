using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Results;
using SharedKernel.Time;

namespace Application.Commands.Users.Update;

internal sealed class UpdateUserCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider timeProvider
) : ICommandHandler<UpdateUserCommand>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await context.Users.SingleOrDefaultAsync(
            u => u.Id == request.UserId,
            cancellationToken
        );

        if (user is null || !user.IsActive)
        {
            return Result.Failure(UserErrors.NotFound(request.UserId));
        }

        user.Name = request.Name ?? user.Name;
        user.UpdatedAt = timeProvider.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
