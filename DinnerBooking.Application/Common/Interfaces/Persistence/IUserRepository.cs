using DinnerBooking.Domain.Entities;

namespace DinnerBooking.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}