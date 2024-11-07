using HotelBookingSystem.Api;
using HotelBookingSystem.Api.Service;
using HotelBookingSystem.Domain;
using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Domain.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<HotelBookingContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("MySQL"), new MySqlServerVersion(new Version(8, 0, 39))));

builder.Services.AddScoped<HotelRepository>();
builder.Services.AddScoped<HotelClientRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<BookedRoomRepository>();

builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<HotelClientService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<BookedRoomService>();

builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddControllers();

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