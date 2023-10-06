using DinnerBooking.Api.AutoMapper;
using DinnerBooking.Api.Errors;
using DinnerBooking.Api.Filters;
using DinnerBooking.Application;
using DinnerBooking.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, DinnerBookingProblemDetailsFactory>();

    // Add Auto Mapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
}

var app = builder.Build();

{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    // app.Map("/error", (HttpContext httpContext) =>
    // {
    //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //     return Results.Problem(title: exception?.Message, statusCode: 400);
    // });
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
