using HotelBookingSystem.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingSystem.Domain;

/// <summary>
/// Database connection
/// </summary>
public class HotelBookingContext(DbContextOptions<HotelBookingContext> options) : DbContext(options)
{
    /// <summary>
    /// Hotel table
    /// </summary>
    public DbSet<Hotel> Hotels { get; set; }

    /// <summary>
    /// Room table
    /// </summary>
    public DbSet<Room> Rooms { get; set; }

    /// <summary>
    /// HotelClient table
    /// </summary>
    public DbSet<HotelClient> HotelClients { get; set; }

    /// <summary>
    /// BookedRoom table
    /// </summary>
    public DbSet<BookedRoom> BookedRooms { get; set; }

    /// <summary>
    /// Overriding the method for establishing relationships between tables
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Room>()
               .HasOne(r => r.Hotel)  
               .WithMany(h => h.Rooms)
               .HasForeignKey(r => r.HotelId);


        modelBuilder.Entity<BookedRoom>()
            .HasOne(br => br.HotelClient)  
            .WithMany(c => c.BookedRooms) 
            .HasForeignKey(br => br.ClientId);

        modelBuilder.Entity<BookedRoom>()
            .HasOne(br => br.Room)  
            .WithMany(r => r.BookedRooms)  
            .HasForeignKey(br => br.RoomId);
    }
}