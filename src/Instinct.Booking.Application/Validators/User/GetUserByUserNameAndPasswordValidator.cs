
using FluentValidation;

namespace Instinct.Booking.Application.Validators.User
{
    // Validación exclusiva para campos que no pertenecen a un modelo específico.
    public class GetUserByUserNameAndPasswordValidator : AbstractValidator<(string, string)>
    {
        public GetUserByUserNameAndPasswordValidator()
        {
            RuleFor(x => x.Item1).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Item2).NotNull().NotEmpty().MaximumLength(50);

        }
    }
}
