using System.ComponentModel.DataAnnotations;

namespace DinnerBooking.Contracts.Authentication;

public class RegisterRequest
{
    [Required(ErrorMessage = "First Name is required!")]
    public string FirstName { get; set; } = String.Empty;

    [Required(ErrorMessage = "Last Name is required!")]
    public string LastName { get; set; } = String.Empty;

    [Required(ErrorMessage = "Email is required!")]
    public string Email { get; set; } = String.Empty;

    [Required(ErrorMessage = "Password is required!")]
    [MinLength(8, ErrorMessage = "Password must be 8 character long")]
    public string Password { get; set; } = String.Empty;
}