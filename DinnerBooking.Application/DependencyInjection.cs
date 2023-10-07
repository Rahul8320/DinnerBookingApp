using DinnerBooking.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using DinnerBooking.Application.Common.Behaviors;
using FluentValidation;

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

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}