namespace HotelBookingSystem.Application.Dto;

/// <summary>
/// DTO class for POST method in hotel room
/// </summary>
public class RoomPostDto
{
    /// <summary>
    /// Hotel room type
    /// </summary>
    public required string TypeRoom { get; set; }

    /// <summary>
    /// Number of rooms of this type
    /// </summary>
    public required int Number { get; set; }

    /// <summary>
    /// Cost per night
    /// </summary>
    public required int Price { get; set; }

    /// <summary>
    /// Hotel ID
    /// </summary>
    public required int HotelId { get; set; }
}