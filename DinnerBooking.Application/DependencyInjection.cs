using DinnerBooking.Application.Services;
using DinnerBooking.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerBooking.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}