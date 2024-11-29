namespace HotelBookingSystem.Application.Dto;

/// <summary>
/// DTO class for POST method in hotel
/// </summary>
public class HotelPostDto
{
    /// <summary>
    /// Hotel name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// City where the hotel is located
    /// </summary>
    public required string City { get; set; }

    /// <summary>
    /// Hotel address
    /// </summary>
    public required string Address { get; set; }
}