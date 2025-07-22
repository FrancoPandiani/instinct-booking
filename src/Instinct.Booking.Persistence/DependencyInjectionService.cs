using Instinct.Booking.Application.DataBase;
using Instinct.Booking.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Instinct.Booking.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Agrego SQL server y la cadena de conexión a la bd
            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(configuration["SQLConnectionString"]));
            services.AddScoped<IDataBaseService, DataBaseService>();

            return services;
        }
    }
}
