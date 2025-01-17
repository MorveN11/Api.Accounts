using Application.Commands.Accounts.Create;
using MediatR;
using Presentation.Extensions;
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
                async (Request request, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = new CreateAccountCommand
                    {
                        Balance = request.Balance,
                        UserId = request.UserId,
                    };

                    Result result = await sender.Send(command, cancellationToken);

                    return result.Match(Results.Created, CustomResults.Problem);
                }
            )
            .WithTags(Tags.Accounts)
            .WithSummary("Create a new account");
    }
}
