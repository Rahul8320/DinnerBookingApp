using DinnerBooking.Application.Common.Interfaces.Auth;
using DinnerBooking.Application.Common.Interfaces.Services;
using DinnerBooking.Infrastructure.Auth;
using DinnerBooking.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerBooking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}