﻿using AutoMapper;
using HotelBookingSystem.Api.Dto;

namespace HotelBookingSystem.Api;

public class Mapping : Profile
{
    public Mapping() 
    {
        CreateMap<HotelGetDto, HotelPostDto>().ReverseMap();
        CreateMap<HotelClientGetDto, HotelClientPostDto>().ReverseMap();
        CreateMap<RoomGetDto, RoomPostDto>().ReverseMap();
        CreateMap<BookedRoomGetDto, BookedRoomPostDto>().ReverseMap();
    }
}