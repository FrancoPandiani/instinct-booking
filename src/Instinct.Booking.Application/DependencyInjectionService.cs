using AutoMapper;
using Instinct.Booking.Application.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instinct.Booking.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config => { config.AddProfile(new MapperProfile());});
            // Registro dicho objeto
            services.AddSingleton(mapper.CreateMapper());
            return services;
        }
    }
}
