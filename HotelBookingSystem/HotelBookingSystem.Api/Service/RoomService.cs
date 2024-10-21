using AutoMapper;
using HotelBookingSystem.Api.Dto;
using HotelBookingSystem.Api.Repository;

namespace HotelBookingSystem.Api.Service;

/// <summary>
/// Service for working with room class 
/// </summary>
public class RoomService(RoomRepository repository, IMapper mapper) : IService<RoomGetDto, RoomPostDto>
{
    /// <inheritdoc />
    public IEnumerable<RoomGetDto> GetAll()
    {
        return repository.GetAll();
    }

    /// <inheritdoc />
    public RoomGetDto? GetById(int id)
    {
        return repository.GetById(id);
    }

    /// <inheritdoc />
    public int Post(RoomPostDto postDto)
    {
        return repository.Post(mapper.Map<RoomGetDto>(postDto));

    }

    /// <inheritdoc />
    public RoomGetDto? Put(int id, RoomPostDto putDto)
    {
        var room = mapper.Map<RoomGetDto>(putDto);
        room.Id = id;
        bool isUpdated = repository.Put(room);
        if (isUpdated)
            return repository.GetById(room.Id);

        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

}