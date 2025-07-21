
namespace Instinct.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNumber
{
    public interface IGetCustomerByDocNumberQuery
    {
        Task<GetCustomerByDocNumberModel> Execute(string docNumber);
    }
}
