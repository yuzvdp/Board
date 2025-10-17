using AutoMapper;
using Board.Contracts.Categories;
using Board.Domain.Entities;

namespace Board.Infrastructure.ComponentRegistrar.MapProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>(MemberList.None);

            CreateMap<CreateCategoryDto, Category>()
                .ForMember(s => s.Id, map => map.Ignore())
                .ForMember(s => s.CreatedAt, map => map.Ignore())
                .ForMember(s => s.Adverts, map => map.Ignore());
        }
    }
}
