using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Domain.Entity;

/// <summary>
/// Booked room
/// </summary>
[Table("BookedRooms")]
public class BookedRoom
{
    /// <summary>
    /// Booked room ID
    /// </summary>
    [Key]
    [Column("BookedRoomID")]
    public required int Id { get; set; }

    /// <summary>
    /// Client ID
    /// </summary>
    [ForeignKey("ClientId")]
    [Column("ClientID")]
    public required int ClientId { get; set; }

    /// <summary>
    /// Hotel room ID
    /// </summary>
    [ForeignKey("RoomId")]
    [Column("RoomID")]
    public required int RoomId { get; set; }

    /// <summary>
    /// Date of entry
    /// </summary>
    [Column("EntryDate")]
    public required DateOnly EntryDate { get; set; }

    /// <summary>
    /// Departure date
    /// </summary>
    [Column("DepartureDate")]
    public required DateOnly DepartureDate { get; set; }

    /// <summary>
    /// Reservation period
    /// </summary>
    [Column("BookingPeriod")]
    public required TimeSpan BookingPeriod { get; set; }

    /// <summary>
    /// Сlient who booked
    /// </summary>
    public required HotelClient HotelClient { get; set; }  

    /// <summary>
    /// Booking room
    /// </summary>
    public required Room Room { get; set; }
}