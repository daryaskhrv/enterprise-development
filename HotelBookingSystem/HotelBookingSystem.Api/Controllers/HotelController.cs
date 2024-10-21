using HotelBookingSystem.Api.Dto;
using HotelBookingSystem.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Api.Controllers;

/// <summary>
/// Controller for working with hotels
/// </summary>
[ApiController]
[Route("[controller]")]
public class HotelController(HotelService service) : ControllerBase
{
    /// <summary>
    /// Get information about all hotels
    /// </summary>
    [HttpGet("allHotels")]
    public ActionResult<IEnumerable<HotelGetDto>> GetAll()
    {
        var hotels = service.GetAll();
        return Ok(hotels);
    }

    /// <summary>
    /// Get information about a hotel by ID
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<HotelGetDto> GetById(int id)
    {
        var hotel = service.GetById(id);
        if (hotel == null)
            return NotFound($"Hotel with id {id} not found."); 
        return Ok(hotel);
    }

    /// <summary>
    /// Insert new hotel
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] HotelPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId }); 
    }

    /// <summary>
    /// Change existing hotel by ID
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<HotelGetDto> Put(int id, [FromBody] HotelPostDto putDto)
    {
        var updatedHotel = service.Put(id, putDto);
        if (updatedHotel == null)
            return NotFound($"Hotel with id {id} not found."); 

        return Ok(updatedHotel); 
    }

    /// <summary>
    /// Delete an existing hotel by ID
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Hotel with id {id} not found."); 

        return Ok($"Hotel with identifier {id} has been deleted."); 
    }

    /// <summary>
    ///  Information about the top 5 hotels with the most bookings
    /// </summary>
    [HttpGet("topHotels")]
    public ActionResult<IEnumerable<HotelGetDto>> GetTopHotels()
    {
        return Ok(service.GetTopHotels());
    }
}