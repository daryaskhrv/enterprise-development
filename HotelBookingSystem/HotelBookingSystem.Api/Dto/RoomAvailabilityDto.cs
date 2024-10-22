namespace HotelBookingSystem.Api.Dto;

/// <summary>
/// Represents the availability of rooms 
/// </summary>
public class RoomAvailabilityDto
{
    /// <summary>
    /// Get the name of the hotel
    /// </summary>
    public required string HotelName { get; set; }

    /// <summary>
    /// Hotel room ID
    /// </summary>
    public required int RoomId { get; set; }

    /// <summary>
    /// Getthe type of the room
    /// </summary>
    public required string RoomType { get; set; }

    /// <summary>
    /// Get the number of available rooms 
    /// </summary>
    public required int AvailableRooms { get; set; }
}