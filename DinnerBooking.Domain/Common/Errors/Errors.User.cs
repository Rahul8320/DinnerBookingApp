using ErrorOr;

namespace DinnerBooking.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "Oops! Duplicate People! You can login using your email!");
    }
}
