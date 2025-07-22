
using Microsoft.Extensions.Configuration;

namespace Instinct.Booking.External.SendGridEmail
{
    // TODO: implementar luego en API
    public class SendGridEmailService
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
