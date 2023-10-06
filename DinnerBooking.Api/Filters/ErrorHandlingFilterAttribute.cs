using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DinnerBooking.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var errorResult = new { error = exception.Message };

        context.Result = new ObjectResult(errorResult)
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
}
