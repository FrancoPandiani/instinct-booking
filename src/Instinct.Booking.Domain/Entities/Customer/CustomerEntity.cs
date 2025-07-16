
using Instinct.Booking.Domain.Entities.Booking;

namespace Instinct.Booking.Domain.Entities.Customer
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public ICollection<BookingEntity> Bookings { get; set; }
        public string FullName { get; set; }
        public string DocumentNumber { get; set; }

    }
}
