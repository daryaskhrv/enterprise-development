using HotelBookingSystem.Domain.Dto;

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
        var hotelExists = context.Hotels.Any(h => h.Id == room.HotelId);
        if (!hotelExists)
            return -1;

        var newId = context.Rooms.Count > 0 ? context.Rooms.Max(r => r.Id) + 1 : 1;
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

        oldValue.Price = room.Price;
        oldValue.Number = room.Number;
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

    /// <summary>
    /// Information about available rooms in all hotels of the selected city
    /// </summary>
    public IEnumerable<RoomAvailabilityDto> FreeRoomsInCity(string city)
    {
        var freeRooms = context.Hotels
            .Where(hotel => hotel.City == city)
            .SelectMany(hotel =>
                context.Rooms
                    .Where(room => room.HotelId == hotel.Id)
                    .Select(room => new RoomAvailabilityDto
                    {
                        HotelName = hotel.Name,
                        RoomId = room.Id,
                        RoomType = room.TypeRoom,
                        AvailableRooms = room.Number -
                                         context.BookedRooms.Count(b => b.RoomId == room.Id)
                    })
                    .Where(r => r.AvailableRooms > 0)
            )
            .ToList();

        return freeRooms;
    }

    /// <summary>
    /// Gets the minimum, average and maximum room rates for each hotel
    /// </summary>
    public IEnumerable<RoomPriceStatisticsDto> GetRoomPriceStatistics()
    {
        return context.Rooms
            .GroupBy(room => room.HotelId)
            .Select(g => new RoomPriceStatisticsDto
            {
                HotelId = g.Key,
                MinPrice = g.Min(room => room.Price),
                AvgPrice = g.Average(room => room.Price),
                MaxPrice = g.Max(room => room.Price)
            })
            .ToList();
    }
}