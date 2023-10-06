using DinnerBooking.Api.AutoMapper;
using DinnerBooking.Api.Common.Errors;
using DinnerBooking.Application;
using DinnerBooking.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, DinnerBookingProblemDetailsFactory>();

    // Add Auto Mapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
}

var app = builder.Build();

{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
