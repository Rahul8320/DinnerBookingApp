using DinnerBooking.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace DinnerBooking.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Add Auto Mapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
            // Add Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).GetTypeInfo().Assembly));

            return services;
        }
    }
}