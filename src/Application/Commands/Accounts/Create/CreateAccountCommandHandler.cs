using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Accounts;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Results;
using SharedKernel.Time;

namespace Application.Commands.Accounts.Create;

internal sealed class CreateAccountCommandHandler(
    IApplicationDbContext context,
    IDateTimeProvider timeProvider
) : ICommandHandler<CreateAccountCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        CreateAccountCommand request,
        CancellationToken cancellationToken
    )
    {
        User? user = await context
            .Users.AsNoTracking()
            .SingleOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound(request.UserId));
        }

        CreateAccountCommandConverter converter = new(timeProvider);

        Account account = converter.Convert(request);

        context.Accounts.Add(account);

        await context.SaveChangesAsync(cancellationToken);

        return account.Id;
    }
}
