
using Microsoft.EntityFrameworkCore;

namespace Instinct.Booking.Application.DataBase.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly IDataBaseService _databaseService;

        // Acá utilizo injección de dependencia
        public DeleteUserCommand(IDataBaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<bool> Execute(int userId)
        {
            // Trae al primer usuario de una tabla, con la condicion que coincida el id del parámetro.
            var entity = await _databaseService.User.FirstOrDefaultAsync(x=> x.UserId == userId);
            if (entity == null)
                return false;
            _databaseService.User.Remove(entity);
            return await _databaseService.SaveAsync();
        }
    }
}
