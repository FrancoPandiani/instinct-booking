
using AutoMapper;
using Instinct.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Microsoft.EntityFrameworkCore;

namespace Instinct.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocNumber
{
    public class GetBookingsByDocNumberQuery : IGetBookingsByDocNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetBookingsByDocNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        // Utilizo nuevamente LINQ
        public async Task<List<GetBookingsByDocNumberModel>> Execute(string docNumber)
        {
            var result = await (from booking in _dataBaseService.Booking
                                join customer in _dataBaseService.Customer
                                on booking.CustomerId equals customer.CustomerId
                                where customer.DocumentNumber == docNumber
                                select new GetBookingsByDocNumberModel
                                {
                                    Code = booking.Code,
                                    RegisterDate = booking.RegisterDate,
                                    Type = booking.Type
                                }).ToListAsync();
            return result;
        }
    }
}
