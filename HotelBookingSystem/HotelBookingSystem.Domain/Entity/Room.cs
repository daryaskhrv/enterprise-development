using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Domain.Entity;

/// <summary>
/// Hotel room
/// </summary>
public class Room
{
    /// <summary>
    /// Hotel room ID
    /// </summary>
    [Key]
    [Column("RoomID")]
    public required int Id { get; set; }

    /// <summary>
    /// Hotel room type
    /// </summary>
    [Column("RoomType")]
    public required string TypeRoom { get; set; }

    /// <summary>
    /// Number of rooms of this type
    /// </summary>
    [Column("Number")]
    public required int Number { get; set; }

    /// <summary>
    /// Cost per night
    /// </summary>
    [Column("Price")]
    public required int Price { get; set; }

    /// <summary>
    /// Hotel ID
    /// </summary>
    [ForeignKey("HotelId")]
    [Column("HotelId")]
    public required int HotelId { get; set; }

    /// <summary>
    /// Book this room
    /// </summary>
    public List<BookedRoom> BookedRooms { get; set; } = [];

    /// <summary>
    /// Hotel
    /// </summary>
    public required Hotel Hotel { get; set; } 
}