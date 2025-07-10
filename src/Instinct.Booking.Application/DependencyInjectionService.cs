using AutoMapper;
using Instinct.Booking.Application.Configuration;
using Instinct.Booking.Application.DataBase.User.Commands.CreateUser;
using Instinct.Booking.Application.DataBase.User.Commands.DeleteUser;
using Instinct.Booking.Application.DataBase.User.Commands.UpdateUser;
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

            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<IUpdateUserPasswordCommand, UpdateUserPasswordCommand>();
            
            return services;
        }
    }
}
