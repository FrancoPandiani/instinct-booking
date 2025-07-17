
using AutoMapper;
using Instinct.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Instinct.Booking.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Instinct.Booking.Application.DataBase.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IGetAllCustomersQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;
        public GetAllCustomersQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<List<GetAllCustomerModel>> Execute()
        {
            var listEntities = await _dataBaseService.Customer.ToListAsync();
            return _mapper.Map<List<GetAllCustomerModel>>(listEntities);
        }
    }
}
