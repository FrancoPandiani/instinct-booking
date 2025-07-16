using AutoMapper;
using Instinct.Booking.Application.DataBase.User.Commands.CreateUser;
using Instinct.Booking.Application.DataBase.User.Commands.UpdateUser;
using Instinct.Booking.Application.DataBase.User.Queries.GetAllUser;
using Instinct.Booking.Application.DataBase.User.Queries.GetUserById;
using Instinct.Booking.Application.DataBase.User.Queries.GetUserByUserNameAndPassword;
using Instinct.Booking.Domain.Entities.User;

namespace Instinct.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
            CreateMap<UserEntity, UpdateUserModel>().ReverseMap();
            CreateMap<UserEntity, GetAllUserModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByIdModel>().ReverseMap();
            CreateMap<UserEntity, GetUserByUserNameAndPasswordModel>().ReverseMap();
        }
    }
}
