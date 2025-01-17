using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Results;
using SharedKernel.Time;

namespace Application.Commands.Accounts.Delete;

internal sealed class DeleteAccountCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider timeProvider
) : ICommandHandler<DeleteAccountCommand>
{
    public async Task<Result> Handle(
        DeleteAccountCommand request,
        CancellationToken cancellationToken
    )
    {
        Account? account = await context.Accounts.SingleOrDefaultAsync(
            a => a.Id == request.AccountId,
            cancellationToken
        );

        if (account is null || !account.IsActive)
        {
            return Result.Failure(AccountErrors.NotFound(request.AccountId));
        }

        account.IsActive = false;
        account.UpdatedAt = timeProvider.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
