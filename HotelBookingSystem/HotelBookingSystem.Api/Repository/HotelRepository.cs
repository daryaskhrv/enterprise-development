using HotelBookingSystem.Api.Dto;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel data
/// </summary>
public class HotelRepository(HotelBookingDbContext context) : IRepository<HotelGetDto>
{
    /// <inheritdoc />
    public IEnumerable<HotelGetDto> GetAll() => context.Hotels;

    /// <inheritdoc />
    public HotelGetDto? GetById(int id) => context.Hotels.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(HotelGetDto hotel)
    {
        int newId = context.Hotels.Count > 0 ? context.Hotels.Max(h => h.Id) + 1 : 1;
        hotel.Id = newId;
        context.Hotels.Add(hotel);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(HotelGetDto hotel)
    {
        var oldValue = GetById(hotel.Id);

        if (oldValue == null)
            return false;

        oldValue.Address = hotel.Address;
        oldValue.City = hotel.City;
        oldValue.Name = hotel.Name;

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
    
}