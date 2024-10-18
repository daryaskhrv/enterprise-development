using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel client data
/// </summary>
internal class HotelClientRepository(HotelBookingDbContext context) : IRepository<HotelClient>
{
    /// <inheritdoc />
    public IEnumerable<HotelClient> GetAll() => context.HotelClients;

    /// <inheritdoc />
    public HotelClient? GetById(int id) => context.HotelClients.Find(x => x.Id == id);

    /// <inheritdoc />
    public void Post(HotelClient hotelClient)
    {
        context.HotelClients.Add(hotelClient);
    }

    /// <inheritdoc />
    public bool Put(HotelClient hotelClient)
    {
        var oldValue = GetById(hotelClient.Id);

        if (oldValue == null)
            return false;

        oldValue.Passport = hotelClient.Passport;
        oldValue.Name = hotelClient.Name;
        oldValue.Surname = hotelClient.Surname;
        oldValue.Patronymic = hotelClient.Patronymic;
        oldValue.Birthdate = hotelClient.Birthdate;
        oldValue.BookedRooms = hotelClient.BookedRooms;

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
}