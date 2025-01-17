using Application.Commands.Users.Create;
using MediatR;
using Microsoft.AspNetCore.OutputCaching;
using Presentation.Infrastructure;
using SharedKernel.Results;

namespace Presentation.Endpoints.Users;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Name { get; init; }

        public required string Pic { get; init; }

        public required string PicPath { get; init; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(
                "api/users",
                async (
                    Request request,
                    ISender sender,
                    IOutputCacheStore cacheStore,
                    CancellationToken cancellationToken
                ) =>
                {
                    var command = new CreateUserCommand
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Pic = request.Pic,
                        PicPath = request.PicPath,
                    };

                    Result<Guid> result = await sender.Send(command, cancellationToken);

                    if (result.IsFailure)
                    {
                        return CustomResults.Problem(result);
                    }

                    await cacheStore.EvictByTagAsync(Tags.Users, cancellationToken);

                    return Results.Ok(result.Value);
                }
            )
            .WithTags(Tags.Users)
            .WithSummary("Create a new user");
    }
}
