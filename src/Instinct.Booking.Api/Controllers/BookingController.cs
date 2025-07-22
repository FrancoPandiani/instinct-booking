using FluentValidation;
using Instinct.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Instinct.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Instinct.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocNumber;
using Instinct.Booking.Application.DataBase.Bookings.Queries.GetBookingsByType;
using Instinct.Booking.Application.Exceptions;
using Instinct.Booking.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace Instinct.Booking.Api.Controllers
{
    [Route("api/v1/booking")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    // Controlador HTTP para la gestión de reservas.
    // Aplica principios de arquitectura limpia: la lógica se delega a comandos y consultas inyectados.
    // Las respuestas están estandarizadas mediante un servicio común.
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateBookingModel model,
            [FromServices] ICreateBookingCommand createBookingCommand,
            [FromServices] IValidator<CreateBookingModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createBookingCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromServices] IGetAllBookingsQuery getAllBookingsQuery)
        {
            var data = await getAllBookingsQuery.Execute();

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-documentNumber")]
        public async Task<IActionResult> GetByDocumentNumber(
            [FromQuery] string documentNumber,
            [FromServices] IGetBookingsByDocNumberQuery getBookingsByDocumentNumberQuery)
        {
            if (string.IsNullOrEmpty(documentNumber))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookingsByDocumentNumberQuery.Execute(documentNumber);

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }

        [HttpGet("get-by-type")]
        public async Task<IActionResult> GetByType(
            [FromQuery] string type,
            [FromServices] IGetBookingsByTypeQuery getBookingsByTypeQuery)
        {
            if (string.IsNullOrEmpty(type))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

            var data = await getBookingsByTypeQuery.Execute(type);

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));

        }
    }
}
