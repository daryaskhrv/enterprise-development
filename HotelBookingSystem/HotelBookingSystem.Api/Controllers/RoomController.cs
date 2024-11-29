using HotelBookingSystem.Application.Dto;
using HotelBookingSystem.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Api.Controllers;

/// <summary>
/// Controller for working with room
/// </summary>
[ApiController]
[Route("[controller]")]
public class RoomController(RoomService service) : ControllerBase
{
    /// <summary>
    /// Get information about all rooms
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<RoomGetDto>> GetAll()
    {
        var rooms = service.GetAll();
        return Ok(rooms);
    }

    /// <summary>
    /// Get information about a room by ID
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<RoomGetDto> GetById(int id)
    {
        var room = service.GetById(id);
        if (room == null)
            return NotFound($"Booking with id {id} not found.");
        return Ok(room);
    }

    /// <summary>
    /// Add new room
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] RoomPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Change existing room by ID
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<RoomGetDto> Put(int id, [FromBody] RoomPostDto putDto)
    {
        var updatedRoom = service.Put(id, putDto);
        if (updatedRoom == null)
            return NotFound($"Booking with id {id} not found.");

        return Ok(updatedRoom);
    }

    /// <summary>
    /// Delete an existing room by ID
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Booking with id {id} not found.");

        return Ok($"Booking with identifier {id} has been deleted.");
    }

    /// <summary>
    /// Gets available rooms in the specified city
    /// </summary>
    [HttpGet("free-rooms/{city}")]
    public ActionResult<IEnumerable<RoomAvailabilityDto>> FreeRoomsInCity(string city)
    {
        var availableRooms = service.FreeRoomsInCity(city);
        if (!availableRooms.Any())
            return NotFound($"No available rooms found in {city}.");

        return Ok(availableRooms);
    }

    /// <summary>
    /// Gets the minimum, average and maximum room rates for each hotel
    /// </summary>
    [HttpGet("price-statistics")]
    public ActionResult<IEnumerable<RoomPriceStatisticsDto>> GetRoomPriceStatistics()
    {
        return Ok(service.GetRoomPriceStatistics());
    }
}