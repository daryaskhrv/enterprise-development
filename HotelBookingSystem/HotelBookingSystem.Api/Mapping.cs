using AutoMapper;
using HotelBookingSystem.Api.Dto;
using HotelBookingSystem.Domain.Entity;

namespace HotelBookingSystem.Api;

public class Mapping : Profile
{
    public Mapping() 
    {
        CreateMap<Hotel, HotelPostDto>().ReverseMap();
        CreateMap<HotelClient, HotelClientPostDto>().ReverseMap();
        CreateMap<Room, RoomPostDto>().ReverseMap();
        CreateMap<BookedRoom, BookedRoomPostDto>().ReverseMap();
    }
}
