using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Results;

namespace Application.Queries.Users.GetById;

internal sealed class GetUserByIdQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetUserByIdQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        User? user = await context
            .Users.Where(a => a.Id == request.UserId)
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        if (user is null || !user.IsActive)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound(request.UserId));
        }

        UserResponse response = new GetUserByIdQueryConverter().Convert(user);

        return response;
    }
}
