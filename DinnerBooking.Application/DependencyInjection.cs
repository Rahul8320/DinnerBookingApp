using DinnerBooking.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using DinnerBooking.Application.Authentication.Commands.Register;
using ErrorOr;
using DinnerBooking.Application.Dtos;
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

            services.AddScoped<IPipelineBehavior<RegisterCommand, ErrorOr<AuthResponseDto>>, ValidateRegisterCommandBehavior>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}