using DinnerBooking.Api.AutoMapper;
using DinnerBooking.Api.Filters;
using DinnerBooking.Application;
using DinnerBooking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    // Add Auto Mapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
}

var app = builder.Build();

{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
