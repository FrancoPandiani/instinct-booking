
namespace Instinct.Booking.Application.DataBase.Customer.Commands
{
    public interface ICreateCustomerCommand
    {
        Task<CreateCustomerModel> Execute(CreateCustomerModel model);
    }
}
