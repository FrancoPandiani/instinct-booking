using Instinct.Booking.Domain.Entities.Booking;
using System;

namespace Instinct.Booking.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserModel
    {
        public ICollection<BookingEntity> Bookings { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
