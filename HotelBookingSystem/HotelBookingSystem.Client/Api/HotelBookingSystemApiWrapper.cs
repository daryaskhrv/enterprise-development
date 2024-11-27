namespace HotelBookingSystem.Client.Api;

public class HotelBookingSystemApiWrapper(IConfiguration configuration) : IHotelBookingSystemApiWrapper
{
    public readonly HotelBookingSystemApi _client = new(configuration["OpenApi:ServerUrl"], new HttpClient());

    public async Task<ICollection<HotelClientGetDto>> GetAllClients() => await _client.HotelClientAllAsync();
    public async Task CreateClient(HotelClientPostDto clientDto) => await _client.HotelClientPOSTAsync(clientDto);
    public async Task<HotelClientGetDto> GetClientById(int id) => await _client.HotelClientGETAsync(id);
    public async Task<HotelClientGetDto> UpdateClient(int id, HotelClientPostDto clientDto) => await _client.HotelClientPUTAsync(id, clientDto);
    public async Task DeleteClient(int id) => await _client.HotelClientDELETEAsync(id);
    public async Task<ICollection<HotelClientGetDto>> GetClientsByHotel(string hotelName) => await _client.HotelAsync(hotelName);
    public async Task<ICollection<HotelClientGetDto>> GetLongestRentalClients() => await _client.LongestRentalAsync();
    
}
