using HotelBookingSystem.Api.Dto;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with booked rooms data
/// </summary>
internal class BookedRoomRepository(HotelBookingDbContext context) : IRepository<BookedRoomGetDto>
{
    /// <inheritdoc />
    public IEnumerable<BookedRoomGetDto> GetAll() => context.BookedRooms;

    /// <inheritdoc />
    public BookedRoomGetDto? GetById(int id) => context.BookedRooms.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(BookedRoomGetDto bookedRoom)
    {
        int newId = context.BookedRooms.Count > 0 ? context.BookedRooms.Max(br => br.Id) + 1 : 1;
        bookedRoom.Id = newId;
        context.BookedRooms.Add(bookedRoom);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(BookedRoomGetDto bookedRoom)
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