using Application.Commands.Users.Delete;
using MediatR;
using Microsoft.AspNetCore.OutputCaching;
using Presentation.Infrastructure;
using SharedKernel.Results;

namespace Presentation.Endpoints.Users;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete(
                "api/users/{id:guid}",
                async (
                    Guid id,
                    ISender sender,
                    IOutputCacheStore cacheStore,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new DeleteUserCommand(id);

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
            .WithSummary("Delete user by ID");
    }
}
