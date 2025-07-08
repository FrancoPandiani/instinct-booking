
using System.Threading.Tasks;

namespace Instinct.Booking.Application.DataBase.User.Commands.UpdateUser
{
    public interface IUpdateUserCommand
    {
        Task<UpdateUserModel> Execute(UpdateUserModel model);
    }
}
