using FluentValidation;

namespace Application.Commands.Accounts.Create;

internal sealed class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
{
    public CreateAccountCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();

        RuleFor(c => c.Balance).GreaterThanOrEqualTo(0);
    }
}
