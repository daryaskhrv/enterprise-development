﻿namespace HotelBookingSystem.Api.Dto;

/// <summary>
/// DTO class for GET method for hotel client
/// </summary>
public class HotelClientGetDto
{
    /// <summary>
    /// Client ID
    /// </summary>
    public required int Id { get; set; }

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

    /// <summary>
    /// Client's date of birth
    /// </summary>
    public required DateOnly Birthdate { get; set; }
}