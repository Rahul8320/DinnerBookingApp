namespace DinnerBooking.Application.Dtos;

public class AuthResponseDto
{
    public UserDto User { get; set; } = null!;
    public string Token { get; set; } = String.Empty;
}