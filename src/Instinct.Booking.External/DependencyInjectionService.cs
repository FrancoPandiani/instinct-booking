using Instinct.Booking.Application.SendGridEmail;
using Instinct.Booking.External.SendGridEmail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Instinct.Booking.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
            return services;
        }
    }
}
