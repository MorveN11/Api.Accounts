using Application.Abstractions.Messaging;
using Application.Commands.Accounts.Create;
using SharedKernel.Results;

namespace Application.Commands.Users.Create;

internal sealed class CreateUserCommandHandler : ICommandHandler<CreateAccountCommand, Guid>
{
    public Task<Result<Guid>> Handle(
        CreateAccountCommand request,
        CancellationToken cancellationToken
    )
    {
        // User? user = await context
        //     .Users.AsNoTracking()
        //     .SingleOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
        //
        // if (user is null)
        // {
        //     return Result.Failure<Guid>(UserErrors.NotFound(request.UserId));
        // }
        //
        // CreateAccountCommandConverter converter = new(timeProvider);
        //
        // Account account = converter.Convert(request);
        //
        // context.Accounts.Add(account);
        //
        // await context.SaveChangesAsync(cancellationToken);
        //
        // return account.Id;
        return Task.FromResult(Result.Success(Guid.NewGuid()));
    }
}
