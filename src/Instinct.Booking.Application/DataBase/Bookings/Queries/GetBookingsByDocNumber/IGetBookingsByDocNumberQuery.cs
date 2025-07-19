
namespace Instinct.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocNumber
{
    public interface IGetBookingsByDocNumberQuery
    {
        Task<List<GetBookingsByDocNumberModel>> Execute(string docNumber);
    }
}
