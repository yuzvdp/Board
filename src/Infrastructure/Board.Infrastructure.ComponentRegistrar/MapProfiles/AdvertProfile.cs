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


            CreateMap<CreateAdvertDto, Advert>(MemberList.None);

        }
    }
}
