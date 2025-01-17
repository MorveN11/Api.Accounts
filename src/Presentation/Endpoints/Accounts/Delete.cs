using Application.Commands.Accounts.Delete;
using MediatR;
using Microsoft.AspNetCore.OutputCaching;
using Presentation.Infrastructure;
using SharedKernel.Results;

namespace Presentation.Endpoints.Accounts;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "api/accounts/{id:guid}",
                async (
                    Guid id,
                    ISender sender,
                    IOutputCacheStore cacheStore,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new DeleteAccountCommand(id);

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
            .WithSummary("Delete account by ID");
    }
}
