using AutoMapper;
using Instinct.Booking.Application.Configuration;
using Instinct.Booking.Application.DataBase.Customer.Commands;
using Instinct.Booking.Application.DataBase.User.Commands.CreateUser;
using Instinct.Booking.Application.DataBase.User.Commands.DeleteUser;
using Instinct.Booking.Application.DataBase.User.Commands.UpdateUser;
using Instinct.Booking.Application.DataBase.User.Queries.GetAllUser;
using Instinct.Booking.Application.DataBase.User.Queries.GetUserById;
using Instinct.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Instinct.Booking.Application.DataBase.User.UpdateUserPassword;
using Microsoft.Extensions.DependencyInjection;

namespace Instinct.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config => { config.AddProfile(new MapperProfile());});
            // Registro el objeto
            services.AddSingleton(mapper.CreateMapper());
            #region User
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByUserNameAndPasswordQuery, GetUserByUserNameAndPasswordQuery>();
            #endregion

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            #endregion

            return services;
        }
    }
}
