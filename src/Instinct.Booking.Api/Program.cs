using Instinct.Booking.Api;
using Instinct.Booking.Application;
using Instinct.Booking.Application.DataBase;
using Instinct.Booking.Common;
using Instinct.Booking.External;
using Instinct.Booking.Persistence;
using Instinct.Booking.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Referencias a los servicios de injección de dependencia
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

app.Run();
