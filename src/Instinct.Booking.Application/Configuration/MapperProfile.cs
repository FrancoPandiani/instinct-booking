using AutoMapper;
using Instinct.Booking.Application.DataBase.User.Commands.CreateUser;
using Instinct.Booking.Domain.Entities.User;

namespace Instinct.Booking.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, CreateUserModel>().ReverseMap();
        }
    }
}
