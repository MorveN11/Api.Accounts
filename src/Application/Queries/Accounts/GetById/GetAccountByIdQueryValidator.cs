using FluentValidation;

namespace Application.Queries.Accounts.GetById;

internal sealed class GetAccountByIdQueryValidator : AbstractValidator<GetAccountByIdQuery>
{
    public GetAccountByIdQueryValidator()
    {
        RuleFor(q => q.AccountId).NotEmpty();
    }
}
