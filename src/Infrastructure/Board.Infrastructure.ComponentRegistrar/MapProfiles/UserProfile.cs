using AutoMapper;
using Board.Contracts.Users;
using Board.Domain.Entities;

namespace Board.Infrastructure.ComponentRegistrar.MapProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>(MemberList.None);

            CreateMap<CreateUserDto, User>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.CreatedAt, map => map.Ignore())
                .ForMember(s => s.Password, map => map.Ignore())
                .ForMember(s => s.Adverts, map => map.Ignore());
        }
    }
}
