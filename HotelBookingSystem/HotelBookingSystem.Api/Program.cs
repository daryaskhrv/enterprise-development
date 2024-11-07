using HotelBookingSystem.Api;
using HotelBookingSystem.Api.Service;
using HotelBookingSystem.Domain;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Domain.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton<HotelBookingDbContext>();

builder.Services.AddDbContext<HotelBookingContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion(new Version(8, 0, 39))));

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
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();