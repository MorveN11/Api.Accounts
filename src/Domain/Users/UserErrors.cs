using SharedKernel.Errors;

namespace Domain.Users;

public static class UserErrors
{
    public static Error NotFound(Guid userId) =>
        Error.NotFound("Users.NotFound", $"The user with the Id = '{userId}' was not found");
}
