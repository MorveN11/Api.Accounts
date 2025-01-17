using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Results;
using SharedKernel.Time;

namespace Application.Commands.Users.Delete;

internal sealed class DeleteUserCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider timeProvider
) : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await context.Users.SingleOrDefaultAsync(
            u => u.Id == request.UserId,
            cancellationToken
        );

        if (user is null || !user.IsActive)
        {
            return Result.Failure(UserErrors.NotFound(request.UserId));
        }

        user.IsActive = false;
        user.UpdatedAt = timeProvider.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
