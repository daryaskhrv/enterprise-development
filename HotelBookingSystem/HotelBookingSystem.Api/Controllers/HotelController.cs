using HotelBookingSystem.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Api.Controllers;

/// <summary>
/// Контроллер для отелей
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    /// <summary>
    /// Получить все отели
    /// </summary>
    [HttpGet]
    public IEnumerable<Hotel> Get()
    {
        return [
            new Hotel {Name = "ff", Address="ff", City = "ff", Id = 1 }
            ];
    }

    // GET api/<HotelController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<HotelController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<HotelController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<HotelController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
