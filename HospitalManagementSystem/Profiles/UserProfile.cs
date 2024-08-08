
using AutoMapper;
using HospitalManagementSystem.Dtos.User;

namespace HospitalManagementSystem.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserForListing>();
            CreateMap<User, UserDto>();
            CreateMap<UserForCreation, User>();
            CreateMap<UserForUpdation, User>();

        }

    }
}
