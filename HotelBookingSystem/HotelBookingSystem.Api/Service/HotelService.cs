using AutoMapper;
using HotelBookingSystem.Api.Dto;
using HotelBookingSystem.Api.Repository;

namespace HotelBookingSystem.Api.Service;

/// <summary>
/// Service for working with hotel class 
/// </summary>
public class HotelService(HotelRepository repository, IMapper mapper) : IService<HotelGetDto, HotelPostDto>
{
    /// <inheritdoc />
    public IEnumerable<HotelGetDto> GetAll()
    {
        return repository.GetAll();
    }

    /// <inheritdoc />
    public HotelGetDto? GetById(int id)
    {
        return repository.GetById(id);
    }

    /// <inheritdoc />
    public int Post(HotelPostDto postDto)
    {
        return repository.Post(mapper.Map<HotelGetDto>(postDto));

    }

    /// <inheritdoc />
    public HotelGetDto? Put(HotelGetDto putDto)
    {
        var hotel = mapper.Map<HotelGetDto>(putDto);
        bool isUpdated = repository.Put(hotel);
        if (isUpdated)
            return repository.GetById(hotel.Id);

        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    ///  Information about the top 5 hotels with the most bookings
    /// </summary>
    public IEnumerable<HotelGetDto?> GetTopHotels()
    {
        return repository.GetTopHotels();
    }
}