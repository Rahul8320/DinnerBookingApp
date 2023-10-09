namespace DinnerBooking.Contracts.Authentication;

public class AuthenticationResponse
{
    public string Id { get; set; } = String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Token { get; set; } = String.Empty;
}