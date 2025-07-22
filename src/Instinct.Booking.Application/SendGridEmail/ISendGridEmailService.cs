using Instinct.Booking.Domain.Models.SendGridEmail;

namespace Instinct.Booking.Application.SendGridEmail
{
    public interface ISendGridEmailService
    {
        Task<bool> Execute(SendGridEmailRequestModel model);
    }
}
