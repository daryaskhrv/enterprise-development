using HotelBookingSystem.Api;
using HotelBookingSystem.Api.Service;
using HotelBookingSystem.Domain.Repository;
using HotelBookingSystem.Domain;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<HotelBookingDbContext>();
builder.Services.AddSingleton<HotelRepository>();
builder.Services.AddSingleton<HotelService>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();