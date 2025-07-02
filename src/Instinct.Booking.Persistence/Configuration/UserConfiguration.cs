using Instinct.Booking.Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Instinct.Booking.Persistence.Configuration
{
    public class UserConfiguration
    {
        // Usar siempre expresión lambda para el builder de EF Core.
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.UserId);
            entityBuilder.Property(x => x.FirstName).IsRequired();
            entityBuilder.Property(x => x.LastName).IsRequired();
            entityBuilder.Property(x => x.UserName).IsRequired();
            entityBuilder.Property(x => x.Password).IsRequired();

            // Un usuario siempre va a tener muchas reservas.
            entityBuilder.HasMany(x => x.Bookings)
                .WithOne(x=>x.User)
                .HasForeignKey(x=>x.UserId);
        }
    }
}
