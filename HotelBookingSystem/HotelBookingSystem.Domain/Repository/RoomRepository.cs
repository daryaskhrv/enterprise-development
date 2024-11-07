using HotelBookingSystem.Domain.Dto;
using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel room data
/// </summary>
public class RoomRepository(HotelBookingContext context) : IRepository<Room>
{
    /// <inheritdoc />
    public IEnumerable<Room> GetAll() => context.Rooms;

    /// <inheritdoc />
    public Room? GetById(int id) => context.Rooms.FirstOrDefault(x => x.Id == id);

    /// <inheritdoc />
    public int Post(Room room)
    {
        var hotelExists = context.Hotels.Any(h => h.Id == room.HotelId);
        if (!hotelExists)
            return -1;

        var newId = context.Rooms.Any() ? context.Rooms.Max(r => r.Id) + 1 : 1;
        room.Id = newId;
        context.Rooms.Add(room);
        context.SaveChanges();
        return newId;
    }

    /// <inheritdoc />
    public bool Put(Room room)
    {
        var oldValue = GetById(room.Id);

        if (oldValue == null)
            return false;

        context.Entry(oldValue).CurrentValues.SetValues(room);
        context.SaveChanges();

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var room = GetById(id);
        if (room == null)
            return false;
        context.Rooms.Remove(room);
        context.SaveChanges();
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