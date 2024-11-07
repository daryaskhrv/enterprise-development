using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel client data
/// </summary>
public class HotelClientRepository(HotelBookingContext context) : IRepository<HotelClient>
{
    /// <inheritdoc />
    public IEnumerable<HotelClient> GetAll() => context.HotelClients;

    /// <inheritdoc />
    public HotelClient? GetById(int id) => context.HotelClients.FirstOrDefault(x => x.Id == id);

    /// <inheritdoc />
    public int Post(HotelClient hotelClient)
    {
        var newId = context.HotelClients.Any() ? context.HotelClients.Max(hc => hc.Id) + 1 : 1;
        hotelClient.Id = newId;
        context.HotelClients.Add(hotelClient);
        context.SaveChanges();
        return newId;
    }

    /// <inheritdoc />
    public bool Put(HotelClient hotelClient)
    {
        var oldValue = GetById(hotelClient.Id);

        if (oldValue == null)
            return false;

        context.Entry(oldValue).CurrentValues.SetValues(hotelClient);
        context.SaveChanges();

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var hotelClient = GetById(id);
        if (hotelClient == null)
            return false;
        context.HotelClients.Remove(hotelClient);
        context.SaveChanges();
        return true;
    }

    /// <summary>
    /// Gets all clients in the specified hotel, sorted by full name
    /// </summary>
    public IEnumerable<HotelClient> GetClientsInHotel(string hotelName)
    {
        var hotelId = context.Hotels
            .Where(hotel => hotel.Name == hotelName)
            .Select(hotel => hotel.Id)
            .FirstOrDefault();

        if (hotelId == 0)
        {
            return Enumerable.Empty<HotelClient>(); 
        }

        var clientIds = context.BookedRooms
            .Where(br => br.RoomId != 0 && context.Rooms
                .Where(r => r.Id == br.RoomId)
                .Select(r => r.HotelId)
                .FirstOrDefault() == hotelId)
            .Select(br => br.ClientId)
            .Distinct();

        return context.HotelClients
            .Where(client => clientIds.Contains(client.Id))
            .OrderBy(client => client.Surname)
            .ThenBy(client => client.Name)
            .ThenBy(client => client.Patronymic)
            .ToList();
    }


    /// <summary>
    /// Gets clients who rented rooms for the longest duration
    /// </summary>
    public IEnumerable<HotelClient?> GetClientsWithLongestRentalPeriod()
    {
        var maxRentalPeriod = context.BookedRooms
            .Max(broom => broom.BookingPeriod.Days);

        return context.BookedRooms
            .Where(broom => broom.BookingPeriod.Days == maxRentalPeriod)
            .Select(broom => new
            {
                Client = context.HotelClients.FirstOrDefault(client => client.Id == broom.ClientId)
            })
            .AsEnumerable()
            .Select(x => x.Client);
    }
}