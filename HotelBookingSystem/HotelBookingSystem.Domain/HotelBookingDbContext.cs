using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Domain;

/// <summary>
/// Class for database
/// </summary>
public class HotelBookingDbContext
{
    public List<Hotel> Hotels { get; set; }

    public List<HotelClient> HotelClients { get; set; }

    public List<Room> Rooms { get; set; }

    public List<BookedRoom> BookedRooms { get; set; }
}
