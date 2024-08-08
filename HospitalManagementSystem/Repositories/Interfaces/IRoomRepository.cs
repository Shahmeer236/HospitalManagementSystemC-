using HospitalManagementSystem.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRoomRepository
{
    Task<List<RoomDto>> GetRoomsAsync(string? search);
    Task<RoomDto> GetRoomByIdAsync(Guid id);
    Task<Guid> AddRoomAsync(RoomForCreation roomForCreation);
    Task<bool> UpdateRoomAsync(RoomForUpdation roomForUpdation);
    Task<bool> DeleteRoomAsync(Guid id);
}
