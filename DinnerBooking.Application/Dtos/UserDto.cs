using DinnerBooking.Domain.UserAggregate.ValueObjects;

namespace DinnerBooking.Application.Dtos;

public class UserDto
{
    public string Id { get; set; } = String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
}