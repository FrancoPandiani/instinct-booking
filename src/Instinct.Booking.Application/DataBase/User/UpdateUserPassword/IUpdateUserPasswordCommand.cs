
namespace Instinct.Booking.Application.DataBase.User.UpdateUserPassword
{
    public interface IUpdateUserPasswordCommand
    {
        Task<bool> Execute(UpdateUserPasswordModel model);
    }
}
