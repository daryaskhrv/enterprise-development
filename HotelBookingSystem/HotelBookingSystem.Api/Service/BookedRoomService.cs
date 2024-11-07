using AutoMapper;
using HotelBookingSystem.Domain.Dto;
using HotelBookingSystem.Domain.Entity;
using HotelBookingSystem.Domain.Repository;

namespace HotelBookingSystem.Api.Service;

/// <summary>
/// Service for working with booked room class 
/// </summary>
public class BookedRoomService(BookedRoomRepository repository, IMapper mapper) : IService<BookedRoomGetDto, BookedRoomPostDto>
{
    /// <inheritdoc />
    public IEnumerable<BookedRoomGetDto> GetAll()
    {
        return mapper.Map<IEnumerable<BookedRoomGetDto>>(repository.GetAll());
    }

    /// <inheritdoc />
    public BookedRoomGetDto? GetById(int id)
    {
        return mapper.Map<BookedRoomGetDto>(repository.GetById(id));
    }

    /// <inheritdoc />
    public int Post(BookedRoomPostDto postDto)
    {
        return repository.Post(mapper.Map<BookedRoom>(postDto));

    }

    /// <inheritdoc />
    public BookedRoomGetDto? Put(int id, BookedRoomPostDto putDto)
    {
        var broom = mapper.Map<BookedRoomGetDto>(putDto);
        broom.Id = id;
        bool isUpdated = repository.Put(mapper.Map<BookedRoom>(broom));
        if (isUpdated)
            return mapper.Map<BookedRoomGetDto>(repository.GetById(broom.Id));

        return null;
    }

    /// <inheritdoc />
    public bool Delete(int id)
    {
        return repository.Delete(id);
    }

}