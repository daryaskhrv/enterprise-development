using HotelBookingSystem.Domain;
using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Application.Repository;

/// <summary>
/// Repository for working with booked rooms data
/// </summary>
public class BookedRoomRepository(HotelBookingContext context) : IRepository<BookedRoom>
{
    /// <inheritdoc />
    public IEnumerable<BookedRoom> GetAll() => context.BookedRooms;

    /// <inheritdoc />
    public BookedRoom? GetById(int id) => context.BookedRooms.FirstOrDefault(x => x.Id == id);

    /// <inheritdoc />
    public int Post(BookedRoom bookedRoom)
    {
        var clientExists = context.HotelClients.Any(c => c.Id == bookedRoom.ClientId);
        var roomExists = context.Rooms.Any(r => r.Id == bookedRoom.RoomId);
        if (!clientExists || !roomExists)
            return -1;

        var newId = context.BookedRooms.Any() ? context.BookedRooms.Max(br => br.Id) + 1 : 1;
        bookedRoom.Id = newId;
        context.BookedRooms.Add(bookedRoom);
        context.SaveChanges();
        return newId;
    }

    /// <inheritdoc />
    public bool Put(BookedRoom bookedRoom)
    {
        var oldValue = GetById(bookedRoom.Id);

        if (oldValue == null)
            return false;

        context.Entry(oldValue).CurrentValues.SetValues(bookedRoom);
        context.SaveChanges();

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var bookedRoom = GetById(id);
        if (bookedRoom == null)
            return false;
        context.BookedRooms.Remove(bookedRoom);
        context.SaveChanges();
        return true;
    }
}