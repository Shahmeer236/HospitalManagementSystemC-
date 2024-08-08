using AutoMapper;
using HospitalManagementSystem.Dtos.Room;

namespace HospitalManagementSystem.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {

            CreateMap<Room, RoomForListing>();
            CreateMap<Room, RoomDto>();
            CreateMap<RoomForCreation, Room>();
            CreateMap<RoomForUpdation, Room>();

        }
    }
}
