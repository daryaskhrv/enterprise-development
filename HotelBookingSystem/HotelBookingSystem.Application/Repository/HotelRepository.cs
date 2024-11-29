using HotelBookingSystem.Domain.Entity;
using HotelBookingSystem.Domain;

namespace HotelBookingSystem.Application.Repository;

/// <summary>
/// Repository for working with hotel data
/// </summary>
public class HotelRepository(HotelBookingContext context) : IRepository<Hotel>
{
    /// <inheritdoc />
    public IEnumerable<Hotel> GetAll() => context.Hotels;

    /// <inheritdoc />
    public Hotel? GetById(int id) => context.Hotels.FirstOrDefault(x => x.Id == id);

    /// <inheritdoc />
    public int Post(Hotel hotel)
    {
        var newId = context.Hotels.Any() ? context.Hotels.Max(h => h.Id) + 1 : 1;
        hotel.Id = newId;
        context.Hotels.Add(hotel);
        context.SaveChanges();
        return newId;
    }

    /// <inheritdoc />
    public bool Put(Hotel hotel)
    {
        var oldValue = GetById(hotel.Id);

        if (oldValue == null)
            return false;

        context.Entry(oldValue).CurrentValues.SetValues(hotel);
        context.SaveChanges();

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var hotel = GetById(id);
        if (hotel == null)
            return false;
        context.Hotels.Remove(hotel);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    ///  Information about the top 5 hotels with the most bookings
    /// </summary>
    public IEnumerable<Hotel?> GetTopHotels()
    {
        var topHotels = context.BookedRooms
            .GroupBy(br => br.RoomId)
            .Select(g => new
            {
                RoomId = g.Key,
                BookingCount = g.Count()
            })
            .Join(
                context.Rooms,
                br => br.RoomId,
                r => r.Id,
                (br, r) => new { r.HotelId, br.BookingCount }
            )
            .GroupBy(x => x.HotelId)
            .Select(g => new
            {
                HotelId = g.Key,
                TotalBookings = g.Sum(x => x.BookingCount)
            })
            .OrderByDescending(x => x.TotalBookings)
            .Take(5)
            .Select(x => context.Hotels.FirstOrDefault(h => h.Id == x.HotelId))
            .Where(h => h != null);

        return topHotels;
    }
}