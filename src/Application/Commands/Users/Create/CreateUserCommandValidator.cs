using FluentValidation;

namespace Application.Commands.Users.Create;

internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name).MaximumLength(100).When(x => x != null);

        RuleFor(x => x.Pic).NotEmpty();

        RuleFor(x => x.PicPath).NotEmpty();
    }
}
