using FluentValidation;

namespace Application.Commands.Accounts.Update;

internal sealed class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
{
    public UpdateAccountCommandValidator()
    {
        RuleFor(x => x.AccountId).NotEmpty();

        RuleFor(x => x.Balance).GreaterThanOrEqualTo(0).When(x => x.Balance.HasValue);
    }
}
