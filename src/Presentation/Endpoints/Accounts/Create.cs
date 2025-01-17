using Application.Commands.Accounts.Create;
using MediatR;
using Microsoft.AspNetCore.OutputCaching;
using Presentation.Infrastructure;
using SharedKernel.Results;

namespace Presentation.Endpoints.Accounts;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public decimal Balance { get; init; }

        public required Guid UserId { get; init; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "api/accounts",
                async (
                    Request request,
                    ISender sender,
                    IOutputCacheStore cacheStore,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new CreateAccountCommand
                    {
                        Balance = request.Balance,
                        UserId = request.UserId,
                    };

                    Result<Guid> result = await sender.Send(command, cancellationToken);

                    if (result.IsFailure)
                    {
                        return CustomResults.Problem(result);
                    }

                    await cacheStore.EvictByTagAsync(Tags.Accounts, cancellationToken);

                    return Results.Ok(result.Value);
                }
            )
            .WithTags(Tags.Accounts)
            .WithSummary("Create a new account");
    }
}
