using DinnerBooking.Api.AutoMapper;
using DinnerBooking.Api.Middleware;
using DinnerBooking.Application;
using DinnerBooking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();

    // Add Auto Mapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
}

var app = builder.Build();

{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
