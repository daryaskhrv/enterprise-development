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

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
