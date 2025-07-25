
namespace Instinct.Booking.Domain.ApplicationInsights
{
    public class InsertApplicationInsightsModel
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public string Detail { get; set; }

        public InsertApplicationInsightsModel(string type, string content,string detail)
        {
            Id = Guid.NewGuid().ToString();
            Type = type;
            Content= content;
            Detail = detail;
        }
    }
}
