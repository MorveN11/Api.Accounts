using Application.Commands.Accounts.Update;
using MediatR;
using Microsoft.AspNetCore.OutputCaching;
using Presentation.Infrastructure;
using SharedKernel.Results;

namespace Presentation.Endpoints.Accounts;

internal sealed class Update : IEndpoint
{
    public sealed class Request
    {
        public decimal? Balance { get; init; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch(
                "api/accounts/{id:guid}",
                async (
                    Guid id,
                    Request request,
                    ISender sender,
                    IOutputCacheStore cacheStore,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new UpdateAccountCommand
                    {
                        AccountId = id,
                        Balance = request.Balance,
                    };

                    Result result = await sender.Send(command, cancellationToken);

                    if (result.IsFailure)
                    {
                        return CustomResults.Problem(result);
                    }

                    await cacheStore.EvictByTagAsync(Tags.Accounts, cancellationToken);

                    return Results.NoContent();
                }
            )
            .WithTags(Tags.Accounts)
            .WithSummary("Update account by ID");
    }
}
