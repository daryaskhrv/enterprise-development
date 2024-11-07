using AutoMapper;
using HotelBookingSystem.Domain.Dto;
using HotelBookingSystem.Domain.Entity;
using HotelBookingSystem.Domain.Repository;

namespace HotelBookingSystem.Api.Service;

/// <summary>
/// Service for working with hotel class 
/// </summary>
public class HotelService(HotelRepository repository, IMapper mapper) : IService<HotelGetDto, HotelPostDto>
{
    /// <inheritdoc />
    public IEnumerable<HotelGetDto> GetAll()
    {
        return mapper.Map<IEnumerable<HotelGetDto>>(repository.GetAll());
    }

    /// <inheritdoc />
    public HotelGetDto? GetById(int id)
    {
        return mapper.Map<HotelGetDto>(repository.GetById(id));
    }

    /// <inheritdoc />
    public int Post(HotelPostDto postDto)
    {
        return repository.Post(mapper.Map<Hotel>(postDto));

    }

    /// <inheritdoc />
    public HotelGetDto? Put(int id, HotelPostDto putDto)
    {
        var hotel = mapper.Map<HotelGetDto>(putDto);
        hotel.Id = id;
        bool isUpdated = repository.Put(mapper.Map<Hotel>(hotel));
        if (isUpdated)
            return mapper.Map<HotelGetDto>(repository.GetById(hotel.Id));

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
        return mapper.Map<IEnumerable<HotelGetDto>>(repository.GetTopHotels());
    }
}