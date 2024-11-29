namespace HotelBookingSystem.Client.Api;

public class HotelBookingSystemApiWrapper(IConfiguration configuration) : IHotelBookingSystemApiWrapper
{
    public readonly HotelBookingSystemApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task<ICollection<HotelGetDto>> GetAllHotels() => await _client.AllHotelsAsync();

    public async Task<HotelGetDto> GetHotelById(int id) => await _client.HotelGETAsync(id);

    public async Task<HotelGetDto> UpdateHotel(int id, HotelPostDto hotelDto) => await _client.HotelPUTAsync(id, hotelDto);

    public async Task DeleteHotel(int id) => await _client.HotelDELETEAsync(id);

    public async Task CreateHotel(HotelPostDto hotelDto) => await _client.HotelPOSTAsync(hotelDto);
}