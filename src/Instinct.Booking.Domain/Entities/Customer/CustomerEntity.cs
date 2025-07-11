﻿using Instinct.Booking.Domain.Entities.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
