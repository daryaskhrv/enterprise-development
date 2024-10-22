using HotelBookingSystem.Api.Dto;
using HotelBookingSystem.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Api.Controllers;

/// <summary>
/// Controller for working with booked room
/// </summary>
[ApiController]
[Route("[controller]")]
public class BookedRoomController(BookedRoomService service) : ControllerBase
{
    /// <summary>
    /// Get information about all booked rooms
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<BookedRoomGetDto>> GetAll()
    {
        var brooms = service.GetAll();
        return Ok(brooms);
    }

    /// <summary>
    /// Get information about a booked room by ID
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<BookedRoomGetDto> GetById(int id)
    {
        var broom = service.GetById(id);
        if (broom == null)
            return NotFound($"Booking with id {id} not found.");
        return Ok(broom);
    }

    /// <summary>
    /// Add new booking
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] BookedRoomPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Change existing booking by ID
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<BookedRoomGetDto> Put(int id, [FromBody] BookedRoomPostDto putDto)
    {
        var updatedBookedRoom = service.Put(id, putDto);
        if (updatedBookedRoom == null)
            return NotFound($"Booking with id {id} not found.");

        return Ok(updatedBookedRoom);
    }

    /// <summary>
    /// Delete an existing booking by ID
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Booking with id {id} not found.");

        return Ok($"Booking with identifier {id} has been deleted.");
    }
}