using AutoMapper;
using Instinct.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Instinct.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Instinct.Booking.Application.DataBase.Customer.Queries.GetAllCustomers;
using Instinct.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocNumber;
using Instinct.Booking.Application.DataBase.Customer.Queries.GetCustomerById;
using Instinct.Booking.Application.DataBase.User.Commands.CreateUser;
using Instinct.Booking.Application.DataBase.User.Commands.UpdateUser;
using Instinct.Booking.Application.DataBase.User.Queries.GetAllUser;
using Instinct.Booking.Application.DataBase.User.Queries.GetUserById;
using Instinct.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Instinct.Booking.Domain.Entities.Booking;
using Instinct.Booking.Domain.Entities.Customer;
using Instinct.Booking.Domain.Entities.User;

namespace Instinct.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
            #endregion

            #region Customer
            CreateMap<CustomerEntity, CreateCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetAllCustomerModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByIdModel>().ReverseMap();
            CreateMap<CustomerEntity, GetCustomerByDocNumberModel>().ReverseMap();
            #endregion

            #region Booking
            CreateMap<BookingEntity, CreateBookingModel>().ReverseMap();
            #endregion
        }
    }
}