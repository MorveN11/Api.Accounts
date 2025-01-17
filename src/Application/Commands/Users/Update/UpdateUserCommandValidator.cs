using FluentValidation;

namespace Application.Commands.Users.Update;

internal sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();

        RuleFor(x => x.Name).MaximumLength(100).When(x => x.Name != null);
    }
}
