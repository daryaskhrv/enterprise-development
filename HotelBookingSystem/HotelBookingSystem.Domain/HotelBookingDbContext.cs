using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Domain;

/// <summary>
/// Класс для базы данных
/// </summary>
public class HotelBookingDbContext
{
    public List<Hotel> Hotels { get; set; }

    public List<HotelClient> HotelClients { get; set; }

    public List<Room> Rooms { get; set; }

    public List<BookedRoom> BookedRooms { get; set; }
}
