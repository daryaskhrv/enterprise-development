using HotelBookingSystem.Api.Dto;

namespace HotelBookingSystem.Domain.Repository;

/// <summary>
/// Repository for working with hotel client data
/// </summary>
internal class HotelClientRepository(HotelBookingDbContext context) : IRepository<HotelClientGetDto>
{
    /// <inheritdoc />
    public IEnumerable<HotelClientGetDto> GetAll() => context.HotelClients;

    /// <inheritdoc />
    public HotelClientGetDto? GetById(int id) => context.HotelClients.Find(x => x.Id == id);

    /// <inheritdoc />
    public int Post(HotelClientGetDto hotelClient)
    {
        int newId = context.HotelClients.Count > 0 ? context.HotelClients.Max(hc => hc.Id) + 1 : 1;
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
}