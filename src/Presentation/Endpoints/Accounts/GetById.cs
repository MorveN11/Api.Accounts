using Application.Queries.Accounts.GetById;
using MediatR;
using Presentation.Extensions;
using Presentation.Infrastructure;
using SharedKernel.Results;

namespace Presentation.Endpoints.Accounts;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
                "api/accounts/{id:guid}",
                async (Guid id, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = new GetAccountByIdQuery(id);

                    Result<AccountResponse> result = await sender.Send(command, cancellationToken);

                    return result.Match(Results.Ok, CustomResults.Problem);
                }
            )
            .WithTags(Tags.Accounts)
            .AddCache(Tags.Accounts)
            .WithSummary("Get account by id");
    }
}
