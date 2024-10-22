namespace HotelBookingSystem.Domain.Dto;

/// <summary>
/// DTO class for POST method in booked room
/// </summary>
public class BookedRoomPostDto
{
    /// <summary>
    /// Client ID
    /// </summary>
    public required int ClientId { get; set; }

    /// <summary>
    /// Hotel room ID
    /// </summary>
    public required int RoomId { get; set; }

    /// <summary>
    /// Date of entry in "yyyy-MM-dd" format
    /// </summary>
    public required string EntryDate { get; set; }

    /// <summary>
    /// Departure date in "yyyy-MM-dd" format
    /// </summary>
    public required string DepartureDate { get; set; }
}