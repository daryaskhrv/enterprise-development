using AutoMapper;
using HotelBookingSystem.Domain.Dto;
using HotelBookingSystem.Domain.Entity;
using HotelBookingSystem.Domain.Repository;

namespace HotelBookingSystem.Api.Service;

/// <summary>
/// Service for working with client class 
/// </summary>
public class HotelClientService(HotelClientRepository repository, IMapper mapper) : IService<HotelClientGetDto, HotelClientPostDto>
{
    /// <inheritdoc />
    public IEnumerable<HotelClientGetDto> GetAll()
    {
        return mapper.Map<IEnumerable<HotelClientGetDto>>(repository.GetAll());
    }

    /// <inheritdoc />
    public HotelClientGetDto? GetById(int id)
    {
        return mapper.Map<HotelClientGetDto>(repository.GetById(id));
    }

    /// <inheritdoc />
    public int Post(HotelClientPostDto postDto)
    {
        return repository.Post(mapper.Map<HotelClient>(postDto));
    }

    /// <inheritdoc />
    public HotelClientGetDto? Put(int id, HotelClientPostDto putDto)
    {
        var hotelClient = mapper.Map<HotelClientGetDto>(putDto);
        hotelClient.Id = id;
        bool isUpdated = repository.Put(mapper.Map<HotelClient>(hotelClient));
        if (isUpdated)
            return mapper.Map<HotelClientGetDto>(repository.GetById(hotelClient.Id));

        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Gets all clients in the specified hotel, sorted by full name
    /// </summary>
    public IEnumerable<HotelClientGetDto> GetClientsInHotel(string hotelName)
    {
        return mapper.Map<IEnumerable<HotelClientGetDto>>(repository.GetClientsInHotel(hotelName));
    }

    /// <summary>
    /// Gets clients who rented rooms for the longest duration
    /// </summary>
    public IEnumerable<HotelClientGetDto?> GetClientsWithLongestRentalPeriod()
    {
        return mapper.Map<IEnumerable<HotelClientGetDto>>(repository.GetClientsWithLongestRentalPeriod());
    }
}