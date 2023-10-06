using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DinnerBooking.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        // var errorResult = new { error = exception.Message };

        var errorResult = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = exception.Message,
            Status = (int)HttpStatusCode.InternalServerError,
        };

        context.Result = new ObjectResult(errorResult)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
