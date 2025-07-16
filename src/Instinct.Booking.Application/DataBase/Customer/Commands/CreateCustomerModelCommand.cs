
using AutoMapper;
using Instinct.Booking.Domain.Entities.Customer;

namespace Instinct.Booking.Application.DataBase.Customer.Commands
{
    public class CreateCustomerModelCommand : ICreateCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateCustomerModelCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateCustomerModel> Execute(CreateCustomerModel model)
        {
            var entity = _mapper.Map<CustomerEntity>(model);
            await _dataBaseService.Customer.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
