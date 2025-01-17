using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Results;
using SharedKernel.Time;

namespace Application.Commands.Accounts.Update;

internal sealed class UpdateAccountCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider timeProvider
) : ICommandHandler<UpdateAccountCommand>
{
    public async Task<Result> Handle(
        UpdateAccountCommand request,
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

        account.Balance = request.Balance ?? account.Balance;
        account.UpdatedAt = timeProvider.UtcNow;

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
