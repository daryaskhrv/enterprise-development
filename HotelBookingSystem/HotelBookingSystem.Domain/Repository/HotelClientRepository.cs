using HotelBookingSystem.Domain.Dto;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel client data
/// </summary>
public class HotelClientRepository(HotelBookingDbContext context) : IRepository<HotelClientGetDto>
{
    /// <inheritdoc />
    public IEnumerable<HotelClientGetDto> GetAll() => context.HotelClients;

    /// <inheritdoc />
    public HotelClientGetDto? GetById(int id) => context.HotelClients.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(HotelClientGetDto hotelClient)
    {
        var newId = context.HotelClients.Count > 0 ? context.HotelClients.Max(hc => hc.Id) + 1 : 1;
        hotelClient.Id = newId;
        context.HotelClients.Add(hotelClient);
        return newId;
    }

    /// <inheritdoc />
    public bool Put(HotelClientGetDto hotelClient)
    {
        var oldValue = GetById(hotelClient.Id);

        if (oldValue == null)
            return false;

        oldValue.Passport = hotelClient.Passport;
        oldValue.Name = hotelClient.Name;
        oldValue.Surname = hotelClient.Surname;
        oldValue.Patronymic = hotelClient.Patronymic;
        oldValue.Birthdate = hotelClient.Birthdate;

        return true;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        var hotelClient = GetById(id);
        if (hotelClient == null)
            return false;
        context.HotelClients.Remove(hotelClient);
        return true;
    }

    /// <summary>
    /// Gets all clients in the specified hotel, sorted by full name
    /// </summary>
    public IEnumerable<HotelClientGetDto> GetClientsInHotel(string hotelName)
    {
        var hotelId = context.Hotels.FirstOrDefault(hotel => hotel.Name == hotelName)?.Id;

        var clientIds = context.BookedRooms
            .Where(br => br.RoomId != 0 && context.Rooms.FirstOrDefault(r => r.Id == br.RoomId)?.HotelId == hotelId)
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
    public IEnumerable<HotelClientGetDto?> GetClientsWithLongestRentalPeriod()
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