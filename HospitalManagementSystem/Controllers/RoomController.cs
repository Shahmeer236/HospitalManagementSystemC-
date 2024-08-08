using HospitalManagementSystem.Dtos.Room;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRooms([FromQuery] string? search)
    {
        var rooms = await _roomService.GetRoomsAsync(search);
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById(Guid id)
    {
        var room = await _roomService.GetRoomByIdAsync(id);
        if (room == null)
        {
            return NotFound();
        }
        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom([FromBody] RoomForCreation roomForCreation)
    {
        var roomId = await _roomService.CreateRoomAsync(roomForCreation);
        return CreatedAtAction(nameof(GetRoomById), new { id = roomId }, roomId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRoom(Guid id, [FromBody] RoomForUpdation roomForUpdation)
    {
        if (id != roomForUpdation.Id)
        {
            return BadRequest();
        }

        var success = await _roomService.UpdateRoomAsync(roomForUpdation);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(Guid id)
    {
        var success = await _roomService.DeleteRoomAsync(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}
