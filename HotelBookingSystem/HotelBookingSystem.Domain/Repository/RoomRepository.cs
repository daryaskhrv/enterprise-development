using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel room data
/// </summary>
public class RoomRepository(HotelBookingDbContext context) : IRepository<Room>
{
    /// <inheritdoc />
    public IEnumerable<Room> GetAll() => context.Rooms;

    /// <inheritdoc />
    public Room? GetById(int id) => context.Rooms.Find(x => x.Id == id);

    /// <inheritdoc />
    public void Post(Room room)
    {
        context.Rooms.Add(room);
    }

    /// <inheritdoc />
    public bool Put(Room room)
    {
        var oldValue = GetById(room.Id);

        if (oldValue == null)
            return false;

        oldValue.HotelId = room.HotelId;
        oldValue.Price = room.Price;
        oldValue.Number = room.Number;
        oldValue.BookedRooms = room.BookedRooms;
        oldValue.TypeRoom = room.TypeRoom;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var room = GetById(id);
        if (room == null)
            return false;
        context.Rooms.Remove(room);
        return true;
    }
}