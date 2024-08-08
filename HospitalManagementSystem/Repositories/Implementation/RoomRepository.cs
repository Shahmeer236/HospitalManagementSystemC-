using AutoMapper;
using HospitalManagementSystem.Dtos.Room;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class RoomRepository : IRoomRepository
{
    private readonly HospitalManagementSystemDbContext _context;
    private readonly IMapper _mapper;

    public RoomRepository(HospitalManagementSystemDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<RoomDto>> GetRoomsAsync(string? search)
    {
        IQueryable<Room> query = _context.Rooms;

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(r => r.RoomNumber.Contains(search) || r.RoomType.Contains(search));
        }

        var rooms = await query.ToListAsync();
        return _mapper.Map<List<RoomDto>>(rooms);
    }

    public async Task<RoomDto> GetRoomByIdAsync(Guid id)
    {
        var room = await _context.Rooms.FindAsync(id);
        return _mapper.Map<RoomDto>(room);
    }

    public async Task<Guid> AddRoomAsync(RoomForCreation roomForCreation)
    {
        var room = _mapper.Map<Room>(roomForCreation);
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room.Id;
    }

    public async Task<bool> UpdateRoomAsync(RoomForUpdation roomForUpdation)
    {
        var room = await _context.Rooms.FindAsync(roomForUpdation.Id);
        if (room == null)
        {
            return false;
        }

        _mapper.Map(roomForUpdation, room);
        _context.Rooms.Update(room);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRoomAsync(Guid id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return false;
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return true;
    }
}
