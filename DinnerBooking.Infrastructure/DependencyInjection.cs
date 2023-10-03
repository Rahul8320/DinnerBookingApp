using DinnerBooking.Application.Common.Interfaces.Auth;
using DinnerBooking.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerBooking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}