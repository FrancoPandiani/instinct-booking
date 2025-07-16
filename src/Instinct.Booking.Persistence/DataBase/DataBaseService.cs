using Instinct.Booking.Application.DataBase;
using Instinct.Booking.Domain.Entities.Booking;
using Instinct.Booking.Domain.Entities.Customer;
using Instinct.Booking.Domain.Entities.User;
using Instinct.Booking.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instinct.Booking.Persistence.DataBase
{
    // Persistence SI puede apuntar a Application y consumir las interfaces, respeta las reglas de dependencia.
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options): base(options)
        {

        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }

        public async Task<bool> SaveAsync()
        { 
            return await SaveChangesAsync() > 0;
        }

        // Construye el modelo solicitado. Las opciones de configuración estan abajo.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        // Configuración
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new CustomerConfiguration(modelBuilder.Entity<CustomerEntity>());
            new BookingConfiguration(modelBuilder.Entity<BookingEntity>());
        }
    }
}
