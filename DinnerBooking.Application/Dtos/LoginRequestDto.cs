namespace DinnerBooking.Application.Dtos
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}