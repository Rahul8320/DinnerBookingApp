using DinnerBooking.Application.Common.Interfaces.Persistence;
using DinnerBooking.Domain.UserAggregate;

namespace DinnerBooking.Infrastructure.Persistence.Repository;

/// <summary>
/// Implements the IUserRepository interface for managing user data in a database.
/// </summary>
public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = [];

    /// <inheritdoc/>
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    /// <inheritdoc/>
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email.Equals(email));
    }

    /// <inheritdoc/>
    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void DeleteUser(string userId)
    {
        throw new NotImplementedException();
    }
}