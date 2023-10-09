using DinnerBooking.Domain.UserAggregate;

namespace DinnerBooking.Application.Common.Interfaces.Persistence;

/// <summary>
/// Interface for managing user data in the repository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="email">The unique identifier of the user.</param>
    /// <returns>The user object if found, or null if not found.</returns>
    User? GetUserByEmail(string email);

    /// <summary>
    /// Adds a new user to the repository.
    /// </summary>
    /// <param name="user">The user object to be added.</param>
    void AddUser(User user);

    /// <summary>
    /// Updates an existing user's information in the repository.
    /// </summary>
    /// <param name="user">The updated user object.</param>
    void UpdateUser(User user);

    /// <summary>
    /// Deletes a user from the repository by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to be deleted.</param>
    void DeleteUser(string userId);
}