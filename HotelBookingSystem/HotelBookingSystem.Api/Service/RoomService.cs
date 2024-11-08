using AutoMapper;
using HotelBookingSystem.Domain.Dto;
using HotelBookingSystem.Domain.Entity;
using HotelBookingSystem.Domain.Repository;

namespace HotelBookingSystem.Api.Service;

/// <summary>
/// Service for working with room class 
/// </summary>
public class RoomService(RoomRepository repository, IMapper mapper) : IService<RoomGetDto, RoomPostDto>
{
    /// <inheritdoc />
    public IEnumerable<RoomGetDto> GetAll()
    {
        return mapper.Map<IEnumerable<RoomGetDto>>(repository.GetAll());
    }

    /// <inheritdoc />
    public RoomGetDto? GetById(int id)
    {
        return mapper.Map<RoomGetDto>(repository.GetById(id));
    }

    /// <inheritdoc />
    public int Post(RoomPostDto postDto)
    {
        return repository.Post(mapper.Map<Room>(postDto));

    }

    /// <inheritdoc />
    public RoomGetDto? Put(int id, RoomPostDto putDto)
    {
        var room = mapper.Map<RoomGetDto>(putDto);
        room.Id = id;
        var isUpdated = repository.Put(mapper.Map<Room>(room));
        if (isUpdated)
            return mapper.Map<RoomGetDto>(repository.GetById(room.Id));

        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

    /// <summary>
    /// Information about available rooms in all hotels of the selected city
    /// </summary>
    public IEnumerable<RoomAvailabilityDto> FreeRoomsInCity(string city)
    {
        return repository.FreeRoomsInCity(city);
    }

    /// <summary>
    /// Gets the minimum, average and maximum room rates for each hotel
    /// </summary>
    public IEnumerable<RoomPriceStatisticsDto> GetRoomPriceStatistics()
    { 
        return repository.GetRoomPriceStatistics();
    }
}