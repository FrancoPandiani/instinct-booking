using Instinct.Booking.Api;
using Instinct.Booking.Application;
using Instinct.Booking.Common;
using Instinct.Booking.External;
using Instinct.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Referencias a los servicios de injección de dependencia
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
