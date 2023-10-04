namespace DinnerBooking.Infrastructure.Auth
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; init; } = String.Empty;
        public int ExpiryMinutes { get; init; }
        public string Issuer { get; init; } = String.Empty;
        public string Audience { get; init; } = String.Empty;
    }
}