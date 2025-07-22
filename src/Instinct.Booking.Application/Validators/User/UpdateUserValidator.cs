
using FluentValidation;
using Instinct.Booking.Application.DataBase.User.Commands.UpdateUser;

namespace Instinct.Booking.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserId)
            .NotNull().WithMessage("El campo 'Nombre' no puede ser nulo.")
            .GreaterThan(0);

            RuleFor(x => x.FirstName)
            .NotNull().WithMessage("El campo 'Nombre' no puede ser nulo.")
            .NotEmpty().WithMessage("El campo 'Nombre' no puede estar vacío.")
            .MaximumLength(50).WithMessage("El campo 'Nombre' no puede superar los 50 caracteres.");

            RuleFor(x => x.LastName)
            .NotNull().WithMessage("El campo 'Apellido' no puede ser nulo.")
            .NotEmpty().WithMessage("El campo 'Apellido' no puede estar vacío.")
            .MaximumLength(50).WithMessage("El campo 'Apellido' no puede superar los 50 caracteres.");

            RuleFor(x => x.UserName)
            .NotNull().WithMessage("El campo 'Usuario' no puede ser nulo.")
            .NotEmpty().WithMessage("El campo 'Usuario' no puede estar vacío.")
            .MaximumLength(50).WithMessage("El campo 'Usuario' no puede superar los 50 caracteres.");

            RuleFor(x => x.Password)
            .NotNull().WithMessage("El campo 'Contraseña' no puede ser nulo.")
            .NotEmpty().WithMessage("El campo 'Contraseña' no puede estar vacío.")
            .MaximumLength(10).WithMessage("El campo 'Contraseña' no puede superar los 10 caracteres.");

        }
    }
}
