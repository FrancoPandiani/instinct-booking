
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Instinct.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNumber
{
    public class GetCustomerByDocNumberQuery : IGetCustomerByDocNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByDocNumberQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByDocNumberModel> Execute(string docNumber)
        {
            var entity = await _dataBaseService.Customer
                .FirstOrDefaultAsync(x => x.DocumentNumber == docNumber);
            return _mapper.Map<GetCustomerByDocNumberModel>(entity);
        }

    }
}
