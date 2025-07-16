
using Instinct.Booking.Domain.Entities.Booking;

namespace Instinct.Booking.Domain.Entities.User
{
    public class UserEntity
    {
        public int UserId { get; set; }
        // Utilizo ICollection para mayor flexibilidad y performance con EF.
        public ICollection<BookingEntity> Bookings { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
