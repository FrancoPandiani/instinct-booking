
using Instinct.Booking.Domain.Entities.Customer;
using Instinct.Booking.Domain.Entities.User;

namespace Instinct.Booking.Domain.Entities.Booking
{
    public class BookingEntity
    {
        public int BookingId { get; set; }
        public UserEntity User { get; set; }
        public CustomerEntity Customer { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }

    }
}
