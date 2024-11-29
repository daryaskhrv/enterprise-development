namespace HotelBookingSystem.Client.Api;

public interface IHotelBookingSystemApiWrapper
{
    Task<ICollection<HotelGetDto>> GetAllHotels();
    Task<HotelGetDto> GetHotelById(int id);
    Task<HotelGetDto> UpdateHotel(int id, HotelPostDto hotelDto);
    Task DeleteHotel(int id);
    Task CreateHotel(HotelPostDto hotelDto);
}