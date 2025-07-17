
using AutoMapper;
using Instinct.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Instinct.Booking.Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;

namespace Instinct.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public DeleteCustomerCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<bool> Execute(int customerId)
        {
            var entity = await _dataBaseService.Customer
                .FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (entity == null)
            {
                return false;
            }
            _dataBaseService.Customer.Remove(entity);
            return await _dataBaseService.SaveAsync();
        }
    }
}
