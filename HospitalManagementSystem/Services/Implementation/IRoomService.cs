using HospitalManagementSystem.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRoomService
{
    Task<List<RoomDto>> GetRoomsAsync(string? search);
    Task<RoomDto> GetRoomByIdAsync(Guid id);
    Task<Guid> CreateRoomAsync(RoomForCreation roomForCreation);
    Task<bool> UpdateRoomAsync(RoomForUpdation roomForUpdation);
    Task<bool> DeleteRoomAsync(Guid id);
}
