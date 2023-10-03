using DinnerBooking.Api.AutoMapper;
using DinnerBooking.Application;
using DinnerBooking.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddApplication().AddInfrastructure();
    builder.Services.AddControllers();

    // Add Auto Mapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
