
using FluentValidation;
using Instinct.Booking.Application.DataBase.Customer.Commands.CreateCustomer;

namespace Instinct.Booking.Application.Validators.Customer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().Length(8);
        }
    }
}
