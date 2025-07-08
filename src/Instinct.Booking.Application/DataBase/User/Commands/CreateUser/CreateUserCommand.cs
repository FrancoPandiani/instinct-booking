using AutoMapper;
using Instinct.Booking.Domain.Entities.User;

namespace Instinct.Booking.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserCommand:ICreateUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        // Acá utilizo injección de dependencia
        public CreateUserCommand(IDataBaseService databaseService, IMapper mapper)
        { 
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CreateUserModel> Execute(CreateUserModel model)
        {
            var entity = _mapper.Map<UserEntity>(model);
            await _databaseService.User.AddAsync(entity);
            await _databaseService.SaveAsync();
            return model;
        }

    }
}
