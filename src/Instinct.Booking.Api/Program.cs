using Instinct.Booking.Application.Interfaces;
using Instinct.Booking.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrego SQL server y la cadena de conexión a la bd
builder.Services.AddDbContext<DataBaseService>(options =>
options.UseSqlServer(builder.Configuration["SQLConnectionString"]));

builder.Services.AddScoped<IDataBaseService, DataBaseService>();

// Agrego servicios al contenedor
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
