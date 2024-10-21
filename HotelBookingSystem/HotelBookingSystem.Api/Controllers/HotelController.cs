using HotelBookingSystem.Api.Dto;
using HotelBookingSystem.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Api.Controllers;

/// <summary>
/// Контроллер для управления отелями
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class HotelController(HotelService service) : ControllerBase
{
    /// <summary>
    /// Получить все отели
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<HotelGetDto>> Get()
    {
        var hotels = service.GetAll();
        return Ok(hotels);
    }

    /// <summary>
    /// Получить отель по ID
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<HotelGetDto> Get(int id)
    {
        var hotel = service.GetById(id);
        if (hotel == null)
            return NotFound(); // Возвращает статус 404, если отель не найден
        return Ok(hotel);
    }

    /// <summary>
    /// Добавить новый отель
    /// </summary>
    [HttpPost]
    public ActionResult<int> Post([FromBody] HotelPostDto postDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); // Проверка валидности данных

        var newId = service.Post(postDto);
        return CreatedAtAction(nameof(Get), new { id = newId }, newId); // Возвращает 201 с ссылкой на новый объект
    }

    /// <summary>
    /// Обновить существующий отель
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<HotelGetDto> Put(int id, [FromBody] HotelGetDto putDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        putDto.Id = id; // Устанавливаем ID перед обновлением
        var updatedHotel = service.Put(putDto);

        if (updatedHotel == null)
            return NotFound(); // Отель не найден, возвращаем 404

        return Ok(updatedHotel); // Возвращаем обновленный отель
    }

    /// <summary>
    /// Удалить отель по ID
    /// </summary>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound(); // Если отель не найден, возвращаем 404

        return NoContent(); // Успешное удаление, возвращаем статус 204
    }

    [HttpGet("top5")]
    public ActionResult<IEnumerable<HotelGetDto>> GetTopHotels()
    {
        var topHotels = service.GetTopHotels();
        return Ok(topHotels);
    }
}
