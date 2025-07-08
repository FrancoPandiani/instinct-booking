
using AutoMapper;
using Instinct.Booking.Domain.Entities.User;

namespace Instinct.Booking.Application.DataBase.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public UpdateUserCommand(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }
        public async Task<UpdateUserModel> Execute(UpdateUserModel model) 
        {            
            var entity = _mapper.Map<UserEntity>(model);
            // No coloco await porque Update no es un metodo asíncrono.
            _databaseService.User.Update(entity);
            await _databaseService.SaveAsync();
            return model;
        }
    }
}
