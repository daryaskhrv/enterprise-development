using AutoMapper;
using HotelBookingSystem.Api.Dto;
using HotelBookingSystem.Domain.Entity;
using HotelBookingSystem.Domain.Repository;

namespace HotelBookingSystem.Api.Service;

public class HotelService(HotelRepository repository, IMapper mapper) : IService<Hotel, HotelPostDto>
{
    /// <inheritdoc />
    public IEnumerable<Hotel> GetAll()
    {
        //return mapper.Map<IEnumerable<Hotel>>(repository.GetAll());
        return repository.GetAll();
    }

    /// <inheritdoc />
    public Hotel? GetById(int id)
    {
        return repository.GetById(id);
    }

    /// <inheritdoc />
    public int Post(HotelPostDto postDto)
    {
        return repository.Post(mapper.Map<Hotel>(postDto));

    }

    /// <inheritdoc />
    public Hotel? Put(Hotel putDto)
    {
        var hotel = mapper.Map<Hotel>(putDto);
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
}
