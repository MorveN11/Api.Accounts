using SharedKernel.Errors;

namespace Domain.Accounts;

public static class AccountErrors
{
    public static Error NotFound(Guid accountId) =>
        Error.NotFound(
            "Accounts.NotFound",
            $"The account with the Id = '{accountId}' was not found"
        );
}
