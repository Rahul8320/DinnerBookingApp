using ErrorOr;

namespace DinnerBooking.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Conflict(code: "Auth.InvalidCredential", description: "Access Blocked! You are not Human!");
    }
}
