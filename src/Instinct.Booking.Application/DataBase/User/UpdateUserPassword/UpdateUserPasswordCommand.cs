
using Microsoft.EntityFrameworkCore;

namespace Instinct.Booking.Application.DataBase.User.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        // No es necesario llamar a mapper
        private readonly IDataBaseService _databaseService;

        public UpdateUserPasswordCommand(IDataBaseService databaseService)
        {
           _databaseService = databaseService; 
        }

        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            // Recordar que cuando no encuentra un registr devuelve null.
            var entity = await _databaseService.User.FirstOrDefaultAsync(x => x.UserId == model.UserId);
            if (entity == null)
            return false;
            entity.Password = model.Password;
            return await _databaseService.SaveAsync();
        }
    }
}
