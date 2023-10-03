namespace DinnerBooking.Contracts.Authentication
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Token { get; set; } = String.Empty;
    }
}