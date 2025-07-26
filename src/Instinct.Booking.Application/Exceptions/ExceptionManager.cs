
using Instinct.Booking.Application.ApplicationInsights;
using Instinct.Booking.Application.Features;
using Instinct.Booking.Common.Constants;
using Instinct.Booking.Domain.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Instinct.Booking.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        private readonly IInsertApplicationInsightsService _insertApplicationInsightsService;
        public ExceptionManager(IInsertApplicationInsightsService insertApplicationInsightsSerice)
        {
            _insertApplicationInsightsService = insertApplicationInsightsSerice;
        }
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(ResponseApiService.Response(
                StatusCodes.Status500InternalServerError, null, context.Exception.Message));
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var metric = new InsertApplicationInsightsModel(
                ApplicationInsightsConstants.METRIC_TYPE_ERROR,
                context.Exception.Message,
                context.Exception.ToString());

            _insertApplicationInsightsService.Execute(metric);
        }
    }
}
