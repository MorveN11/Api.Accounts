using FluentValidation;

namespace Application.Commands.Accounts.Delete;

internal sealed class DeleteAccountCommandValidator : AbstractValidator<DeleteAccountCommand>
{
    public DeleteAccountCommandValidator()
    {
        RuleFor(x => x.AccountId).NotEmpty();
    }
}
