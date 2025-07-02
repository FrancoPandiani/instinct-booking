using Instinct.Booking.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instinct.Booking.Application.Interfaces
{
    // Esta interfaz si puede ser consumida por api
    public interface IDataBaseService
    {
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UserEntity> Customer { get; set; }
        public DbSet<UserEntity> Booking { get; set; }

        Task<bool> SaveAsync();
    }
}
