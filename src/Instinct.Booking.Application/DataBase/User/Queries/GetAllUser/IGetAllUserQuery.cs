﻿namespace Instinct.Booking.Application.DataBase.User.Queries.GetAllUser
{
    public interface IGetAllUserQuery
    {
        Task<List<GetAllUserModel>> Execute();
    }
}
