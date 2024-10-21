﻿using HotelBookingSystem.Api.Dto;
using HotelBookingSystem.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Api.Controllers;

/// <summary>
/// Controller for working with clients
/// </summary>
[ApiController]
[Route("[controller]")]
public class HotelClientController(HotelClientService service) : ControllerBase
{
    /// <summary>
    /// Get information about all clients
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<HotelClientGetDto>> GetAll()
    {
        var clients = service.GetAll();
        return Ok(clients);
    }

    /// <summary>
    /// Get information about a client by ID
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<HotelClientGetDto> GetById(int id)
    {
        var client = service.GetById(id);
        if (client == null)
            return NotFound($"Client with id {id} not found.");
        return Ok(client);
    }

    /// <summary>
    /// Insert new client
    /// </summary>
    [HttpPost]
    public ActionResult<object> Post([FromBody] HotelClientPostDto postDto)
    {
        var newId = service.Post(postDto);
        return Ok(new { id = newId });
    }

    /// <summary>
    /// Change existing client by ID
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<HotelClientGetDto> Put(int id, [FromBody] HotelClientPostDto putDto)
    {
        var updatedHotelClient = service.Put(id, putDto);
        if (updatedHotelClient == null)
            return NotFound($"Client with id {id} not found.");

        return Ok(updatedHotelClient);
    }

    /// <summary>
    /// Delete an existing client by ID
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = service.Delete(id);
        if (!isDeleted)
            return NotFound($"Client with id {id} not found.");

        return Ok($"Client with identifier {id} has been deleted.");
    }
}