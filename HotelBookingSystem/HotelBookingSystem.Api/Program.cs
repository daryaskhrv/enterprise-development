using HotelBookingSystem.Api;
using HotelBookingSystem.Api.Repository;
using HotelBookingSystem.Api.Service;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<HotelBookingDbContext>();

builder.Services.AddSingleton<HotelRepository>();
builder.Services.AddSingleton<HotelClientRepository>();
builder.Services.AddSingleton<RoomRepository>();
builder.Services.AddSingleton<BookedRoomRepository>();

builder.Services.AddSingleton<HotelService>();
builder.Services.AddSingleton<HotelClientService>();
builder.Services.AddSingleton<RoomService>();
builder.Services.AddSingleton<BookedRoomService>();

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();