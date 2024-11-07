using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingSystem.Domain.Entity;

/// <summary>
/// Hotel clients
/// </summary>
[Table("HotelClients")]
public class HotelClient
{
    /// <summary>
    /// Client ID
    /// </summary>
    [Key]
    [Column("ClientID")]
    public required int Id { get; set; }

    /// <summary>
    /// The number of passport of the lodger
    /// </summary>
    [Column("PassportNumber")]
    public required int Passport { get; set; }

    /// <summary>
    /// Client's name
    /// </summary>
    [Column("FirstName")]
    public required string Name { get; set; }

    /// <summary>
    /// Client's surname
    /// </summary>
    [Column("LastName")]
    public required string Surname { get; set; }

    /// <summary>
    /// Client's patronymic
    /// </summary>
    [Column("Patronymic")]
    public string? Patronymic { get; set; }

    /// <summary>
    /// Client's date of birth
    /// </summary>
    [Column("Birthdate")]
    public required DateOnly Birthdate { get; set; }

    /// <summary>
    /// Rooms booked by the client
    /// </summary>
    public List<BookedRoom> BookedRooms { get; set; } = [];
}