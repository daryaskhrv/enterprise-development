namespace HotelBookingSystem.Client.Api;

public interface IHotelBookingSystemApiWrapper
{
    Task<ICollection<HotelClientGetDto>> GetAllClients();
    Task CreateClient(HotelClientPostDto clientDto);
    Task<HotelClientGetDto> GetClientById(int id);
    Task<HotelClientGetDto> UpdateClient(int id, HotelClientPostDto clientDto);
    Task DeleteClient(int id);
    Task<ICollection<HotelClientGetDto>> GetClientsByHotel(string hotelName);
    Task<ICollection<HotelClientGetDto>> GetLongestRentalClients();
}
