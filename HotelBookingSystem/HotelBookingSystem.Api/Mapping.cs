﻿using AutoMapper;
using HotelBookingSystem.Domain.Dto;

namespace HotelBookingSystem.Api;

public class Mapping : Profile
{
    public Mapping() 
    {
        CreateMap<HotelGetDto, HotelPostDto>().ReverseMap();
        CreateMap<HotelClientGetDto, HotelClientPostDto>().ReverseMap();
        CreateMap<RoomGetDto, RoomPostDto>().ReverseMap();
        CreateMap<BookedRoomGetDto, BookedRoomPostDto>().ReverseMap();

        CreateMap<HotelClientPostDto, HotelClientGetDto>()
            .ForMember(dest => dest.Birthdate, opt =>
                opt.MapFrom(src => DateOnly.Parse(src.Birthdate)));

        CreateMap<BookedRoomPostDto, BookedRoomGetDto>()
            .ForMember(dest => dest.EntryDate, opt =>
                opt.MapFrom(src => DateOnly.Parse(src.EntryDate)))
            .ForMember(dest => dest.DepartureDate, opt =>
                opt.MapFrom(src => DateOnly.Parse(src.DepartureDate)))
            .ForMember(dest => dest.BookingPeriod, opt =>
                opt.MapFrom(src =>
                    (DateTime.Parse(src.DepartureDate) - DateTime.Parse(src.EntryDate)).Duration()));
    }
}