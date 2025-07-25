
using Instinct.Booking.Domain.ApplicationInsights;

namespace Instinct.Booking.Application.ApplicationInsights
{
    public interface IInsertApplicationInsightsService
    {
        bool Execute(InsertApplicationInsightsModel metric);
    }
}
