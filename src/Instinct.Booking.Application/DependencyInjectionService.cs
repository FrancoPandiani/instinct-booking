using AutoMapper;
using FluentValidation;
using Instinct.Booking.Application.Configuration;
using Instinct.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Instinct.Booking.Application.DataBase.Bookings.Queries.GetAllBookings;
using Instinct.Booking.Application.DataBase.Bookings.Queries.GetBookingsByDocNumber;
using Instinct.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Instinct.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Instinct.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Instinct.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Instinct.Booking.Application.DataBase.User.Commands.CreateUser;
using Instinct.Booking.Application.DataBase.User.Commands.DeleteUser;
using Instinct.Booking.Application.DataBase.User.Commands.UpdateUser;
using Instinct.Booking.Application.DataBase.User.Queries.GetAllUser;
using Instinct.Booking.Application.DataBase.User.Queries.GetUserById;
using Instinct.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Instinct.Booking.Application.DataBase.User.UpdateUserPassword;
using Instinct.Booking.Application.Validators.User;
using Microsoft.Extensions.DependencyInjection;

namespace Instinct.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config => { config.AddProfile(new MapperProfile());});

            // Registro AutoMapper como única instancia
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
            services.AddTransient<IDeleteCustomerCommand, DeleteCustomerCommand>();
            services.AddTransient<IGetAllCustomersQuery, GetAllCustomersQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            #endregion

            #region Bookings
            services.AddTransient<ICreateBookingCommand, CreateBookingCommand>();
            services.AddTransient<IGetAllBookingsQuery, GetAllBookingsQuery>();
            services.AddTransient<IGetBookingsByDocNumberQuery, GetBookingsByDocNumberQuery>();
            services.AddTransient<IGetBookingsByDocNumberQuery, GetBookingsByDocNumberQuery>();
            #endregion

            #region Validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<UpdateUserPasswordModel>, UpdateUserPasswordValidator>();
            services.AddScoped<IValidator<(string,string)>, GetUserByUserNameAndPasswordValidator>();
            #endregion


            return services;
        }
    }
}
