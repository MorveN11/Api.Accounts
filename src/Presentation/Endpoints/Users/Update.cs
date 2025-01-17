using Application.Commands.Users.Update;
using MediatR;
using Microsoft.AspNetCore.OutputCaching;
using Presentation.Infrastructure;
using SharedKernel.Results;

namespace Presentation.Endpoints.Users;

internal sealed class Update : IEndpoint
{
    public sealed class Request
    {
        public string? Name { get; init; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch(
                "api/users/{id:guid}",
                async (
                    Guid id,
                    Request request,
                    ISender sender,
                    IOutputCacheStore cacheStore,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new UpdateUserCommand { UserId = id, Name = request.Name };

                    Result result = await sender.Send(command, cancellationToken);

                    if (result.IsFailure)
                    {
                        return CustomResults.Problem(result);
                    }

                    await cacheStore.EvictByTagAsync(Tags.Users, cancellationToken);

                    return Results.NoContent();
                }
            )
            .WithTags(Tags.Users)
            .WithSummary("Update user by ID");
    }
}
