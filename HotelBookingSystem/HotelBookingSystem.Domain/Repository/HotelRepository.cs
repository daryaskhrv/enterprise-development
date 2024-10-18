using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel data
/// </summary>
public class HotelRepository(HotelBookingDbContext context) : IRepository<Hotel>
{
    /// <inheritdoc />
    public IEnumerable<Hotel> GetAll() => context.Hotels;

    /// <inheritdoc />
    public Hotel? GetById(int id) => context.Hotels.Find(x => x.Id == id);

    /// <inheritdoc />
    public void Post(Hotel hotel)
    {
        context.Hotels.Add(hotel);
    }

    /// <inheritdoc />
    public bool Put(Hotel hotel)
    {
        var oldValue = GetById(hotel.Id);

        if (oldValue == null)
            return false;

        oldValue.Address = hotel.Address;
        oldValue.City = hotel.City;
        oldValue.Name = hotel.Name;
        oldValue.Rooms = hotel.Rooms;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var hotel = GetById(id);
        if (hotel == null)
            return false;
        context.Hotels.Remove(hotel);
        return true;
    }

    /// <summary>
    ///  Information about the top 5 hotels with the most bookings
    /// </summary>
    public IEnumerable<(Hotel hotel, int bookingCount)> GetTopHotels()
    {
        return context.Hotels
            .Select(hotel => new
            {
                Hotel = hotel,
                BookingCount = context.Rooms
                    .Where(room => room.HotelId == hotel.Id)
                    .SelectMany(room => room.BookedRooms)
                    .Count()
            })
            .OrderByDescending(hotel => hotel.BookingCount)
            .Take(5)
            .AsEnumerable()
            .Select(hotel => (hotel.Hotel, hotel.BookingCount));
    }
}