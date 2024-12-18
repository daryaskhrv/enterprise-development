﻿namespace HotelBookingSystem.Application.Dto;

/// <summary>
/// DTO class for POST method for hotel client
/// </summary>
public class HotelClientPostDto
{
    /// <summary>
    /// The number of passport of the lodger
    /// </summary>
    public required int Passport { get; set; }

    /// <summary>
    /// Client's name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Client's surname
    /// </summary>
    public required string Surname { get; set; }

    /// <summary>
    /// Client's patronymic
    /// </summary>
    public string? Patronymic { get; set; }

    /*/// <summary>
    /// Client's date of birth
    /// </summary>
    public required DateOnly Birthdate { get; set; }*/

    /// <summary>
    /// Client's date of birth in "yyyy-MM-dd" format
    /// </summary>
    public required string Birthdate { get; set; }
}