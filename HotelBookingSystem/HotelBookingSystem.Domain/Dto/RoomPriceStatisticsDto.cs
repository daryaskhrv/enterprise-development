namespace HotelBookingSystem.Domain.Dto;

/// <summary>
/// DTO for representing room price statistics in hotels.
/// </summary>
public class RoomPriceStatisticsDto
{
    /// <summary>
    /// The identifier of the hotel 
    /// </summary>
    public required int HotelId { get; set; }

    /// <summary>
    /// The minimum room price 
    /// </summary>
    public required int MinPrice { get; set; }

    /// <summary>
    /// The average room price 
    /// </summary>
    public required double AvgPrice { get; set; }

    /// <summary>
    /// The maximum room price 
    /// </summary>
    public required int MaxPrice { get; set; }
}