
using FluentValidation;
using Instinct.Booking.Application.DataBase.User.UpdateUserPassword;

namespace Instinct.Booking.Application.Validators.User
{
    public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(x => x.UserId)
            .NotNull().WithMessage("El campo 'Nombre' no puede ser nulo.")
            .GreaterThan(0);

            RuleFor(x => x.Password)
            .NotNull().WithMessage("El campo 'Contraseña' no puede ser nulo.")
            .NotEmpty().WithMessage("El campo 'Contraseña' no puede estar vacío.")
            .MaximumLength(10).WithMessage("El campo 'Contraseña' no puede superar los 10 caracteres.");
        }
    }
}
