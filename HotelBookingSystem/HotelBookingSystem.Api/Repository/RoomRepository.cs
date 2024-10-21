using HotelBookingSystem.Api.Dto;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel room data
/// </summary>
public class RoomRepository(HotelBookingDbContext context) : IRepository<RoomGetDto>
{
    /// <inheritdoc />
    public IEnumerable<RoomGetDto> GetAll() => context.Rooms;

    /// <inheritdoc />
    public RoomGetDto? GetById(int id) => context.Rooms.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(RoomGetDto room)
    {
        int newId = context.Rooms.Count > 0 ? context.Rooms.Max(r => r.Id) + 1 : 1;
        room.Id = newId;
        context.Rooms.Add(room);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(RoomGetDto room)
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