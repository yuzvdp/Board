using AutoMapper;
using Board.Contracts.Adverts;
using Board.Domain.Entities;

namespace Board.Infrastructure.ComponentRegistrar.MapProfiles
{
    public class AdvertProfile : Profile
    {
        public AdvertProfile()
        {
            CreateMap<AdvertDto, Advert>(MemberList.None);
            CreateMap<Advert, AdvertDto>(MemberList.None);

            CreateMap<CreateAdvertDto, Advert>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.CreatedAt, map => map.Ignore())
                .ForMember(s => s.User, map => map.Ignore())
                .ForMember(s => s.Category, map => map.Ignore());

        }
    }
}
