using DinnerBooking.Application.AutoMapper;
using DinnerBooking.Application.Services;
using DinnerBooking.Application.Services.Auth;
using DinnerBooking.Application.Services.Auth.Interfaces;
using DinnerBooking.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerBooking.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Add Auto Mapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IAuthCommandService, AuthCommandService>();
            services.AddScoped<IAuthQueryService, AuthQueryService>();

            return services;
        }
    }
}