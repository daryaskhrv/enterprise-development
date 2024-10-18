using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with booked rooms data
/// </summary>
internal class BookedRoomRepository(HotelBookingDbContext context) : IRepository<BookedRoom>
{
    /// <inheritdoc />
    public IEnumerable<BookedRoom> GetAll() => context.BookedRooms;

    /// <inheritdoc />
    public BookedRoom? GetById(int id) => context.BookedRooms.Find(x => x.Id == id);

    /// <inheritdoc />
    public void Post(BookedRoom bookedRoom)
    {
        context.BookedRooms.Add(bookedRoom);
    }

    /// <inheritdoc />
    public bool Put(BookedRoom bookedRoom)
    {
        var oldValue = GetById(bookedRoom.Id);

        if (oldValue == null)
            return false;

        oldValue.ClientId = bookedRoom.ClientId;
        oldValue.RoomId = bookedRoom.RoomId;
        oldValue.EntryDate = bookedRoom.EntryDate;
        oldValue.DepartureDate = bookedRoom.DepartureDate;
        oldValue.BookingPeriod = bookedRoom.BookingPeriod;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var bookedRoom = GetById(id);
        if (bookedRoom == null)
            return false;
        context.BookedRooms.Remove(bookedRoom);
        return true;
    }
}