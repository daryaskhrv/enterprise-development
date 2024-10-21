using HotelBookingSystem.Api.Dto;

namespace HotelBookingSystem.Domain;

/// <summary>
/// Class for database
/// </summary>
public class HotelBookingDbContext
{
    public List<HotelGetDto> Hotels { get; set; }

    public List<HotelClientGetDto> HotelClients { get; set; }

    public List<RoomGetDto> Rooms { get; set; }

    public List<BookedRoomGetDto> BookedRooms { get; set; }

    public HotelBookingDbContext()
    {
        Hotels = new List<HotelGetDto>();
        HotelClients = new List<HotelClientGetDto>();
        Rooms = new List<RoomGetDto>();
        BookedRooms = new List<BookedRoomGetDto>();
    }
}