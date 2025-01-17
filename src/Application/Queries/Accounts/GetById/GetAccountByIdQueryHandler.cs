using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Results;

namespace Application.Queries.Accounts.GetById;

internal sealed class GetAccountByIdQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetAccountByIdQuery, AccountResponse>
{
    public async Task<Result<AccountResponse>> Handle(
        GetAccountByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        Account? account = await context
            .Accounts.Where(a => a.Id == request.AccountId)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        if (account is null || !account.IsActive)
        {
            return Result.Failure<AccountResponse>(AccountErrors.NotFound(request.AccountId));
        }

        AccountResponse response = new GetAccountByIdQueryConverter().Convert(account);

        return response;
    }
}
