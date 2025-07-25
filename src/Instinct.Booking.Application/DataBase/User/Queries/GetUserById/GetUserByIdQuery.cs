﻿
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Instinct.Booking.Application.DataBase.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IDataBaseService _databaseService;
        private readonly IMapper _mapper;

        public GetUserByIdQuery(IDataBaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByIdModel> Execute(int userId)
        {
            var entity = await _databaseService.User
                .FirstOrDefaultAsync(x => x.UserId == userId);
            // Recordar que el metodo FODA puede devolver null, mapper no mapearia y devolveria null también.
            return _mapper.Map<GetUserByIdModel>(entity);
        }
    }
    
}
