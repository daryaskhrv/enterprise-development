using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Domain.Entity;

/// <summary>
/// Hotel
/// </summary>
[Table("Hotels")]
public class Hotel
{
    /// <summary>
    /// Hotel ID
    /// </summary>
    [Key]  
    [Column("HotelID")]
    public required int Id { get; set; }

    /// <summary>
    /// Hotel name
    /// </summary>
    [Column("HotelName")]
    public required string Name { get; set; }

    /// <summary>
    /// City where the hotel is located
    /// </summary>
    [Column("City")]
    public required string City { get; set; }

    /// <summary>
    /// Hotel address
    /// </summary>
    [Column("Address")]
    public required string Address { get; set; }

    /// <summary>
    /// Hotel rooms
    /// </summary>
    public List<Room> Rooms { get; set; } = [];
}