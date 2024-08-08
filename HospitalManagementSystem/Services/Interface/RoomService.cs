using HospitalManagementSystem.Dtos.Room;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;

    public RoomService(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public Task<List<RoomDto>> GetRoomsAsync(string? search) =>
        _roomRepository.GetRoomsAsync(search);

    public Task<RoomDto> GetRoomByIdAsync(Guid id) =>
        _roomRepository.GetRoomByIdAsync(id);

    public Task<Guid> CreateRoomAsync(RoomForCreation roomForCreation) =>
        _roomRepository.AddRoomAsync(roomForCreation);

    public Task<bool> UpdateRoomAsync(RoomForUpdation roomForUpdation) =>
        _roomRepository.UpdateRoomAsync(roomForUpdation);

    public Task<bool> DeleteRoomAsync(Guid id) =>
        _roomRepository.DeleteRoomAsync(id);
}
