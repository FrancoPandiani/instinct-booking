
namespace Instinct.Booking.Application.DataBase.Customer.Queries.GetAllCustomers
{
    public interface IGetAllCustomersQuery
    {
        Task<List<GetAllCustomerModel>> Execute();
    }
}
