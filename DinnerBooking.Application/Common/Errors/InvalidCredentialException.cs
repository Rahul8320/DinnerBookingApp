using System.Net;

namespace DinnerBooking.Application.Common.Errors;

public class InvalidCredentialException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotAcceptable;

    public string ErrorMessage => "Invalid Credentials";
}
