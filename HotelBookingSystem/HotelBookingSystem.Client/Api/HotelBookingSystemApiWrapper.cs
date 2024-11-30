namespace HotelBookingSystem.Client.Api;

public class HotelBookingSystemApiWrapper(IConfiguration configuration) : IHotelBookingSystemApiWrapper
{
    public readonly HotelBookingSystemApi Client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task<ICollection<HotelGetDto>> GetAllHotels() => await Client.AllHotelsAsync();

    public async Task<HotelGetDto> GetHotelById(int id) => await Client.HotelGETAsync(id);

    public async Task<HotelGetDto> UpdateHotel(int id, HotelPostDto hotelDto) => await Client.HotelPUTAsync(id, hotelDto);

    public async Task DeleteHotel(int id) => await Client.HotelDELETEAsync(id);

    public async Task CreateHotel(HotelPostDto hotelDto) => await Client.HotelPOSTAsync(hotelDto);
}