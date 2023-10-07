using DinnerBooking.Application.Authentication.Commands.Register;
using DinnerBooking.Application.Dtos;
using ErrorOr;
using FluentValidation;
using MediatR;

namespace DinnerBooking.Application.Common.Behaviors;

public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthResponseDto>>
{
    private readonly IValidator<RegisterCommand> _validator;

    public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<ErrorOr<AuthResponseDto>> Handle(
        RegisterCommand request,
        RequestHandlerDelegate<ErrorOr<AuthResponseDto>> next,
        CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid) return await next();

        var errors = validationResult.Errors.ConvertAll(validationFailure => Error.Validation(
            validationFailure.PropertyName,
            validationFailure.ErrorMessage)
        );

        return errors;
    }
}