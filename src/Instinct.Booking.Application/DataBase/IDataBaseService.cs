﻿using Instinct.Booking.Domain.Entities.Booking;
using Instinct.Booking.Domain.Entities.Customer;
using Instinct.Booking.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Instinct.Booking.Application.DataBase
{
    // Esta interfaz si puede ser consumida por api
    public interface IDataBaseService
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }

        Task<bool> SaveAsync();
    }
}
