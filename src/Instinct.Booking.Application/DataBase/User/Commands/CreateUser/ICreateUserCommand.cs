using System;

namespace Instinct.Booking.Application.DataBase.User.Commands.CreateUser
{
    public interface ICreateUserCommand
    {  
        Task<CreateUserModel> Execute(CreateUserModel model);
    }
}
