using AutoFixture;
using AutoMapper;
using Board.Contracts.Categories;
using Board.Domain.Entities;
using Board.Infrastructure.ComponentRegistrar.MapProfiles;
using Shouldly;

namespace Board.Unit.Tests.Board.Infrastructure.ComponentRegistrar.MapProfiles
{
    public class CategoryProfileTests
    {
        private readonly MapperConfiguration _configurationProvider;

        private IMapper Mapper { get; }
        private Fixture Fixture { get; }

        public CategoryProfileTests()
        {
            _configurationProvider = new MapperConfiguration(delegate (IMapperConfigurationExpression configure)
            {
                configure.AddProfiles(new List<Profile>
                {
                    new CategoryProfile(),
                });
            });
            Fixture = new Fixture();
            Mapper = _configurationProvider.CreateMapper();
        }

        [Fact]
        public void AutoMapperProfile_CheckConfigurationIsValid()
        {
            _configurationProvider.AssertConfigurationIsValid();
        }

        /// <summary>
        /// Проверка <see cref="CategoryProfile"/>.
        /// </summary>
        [Fact]
        public void CategoryProfile_Check()
        {
            // Arrange
            var title = Fixture.Create<string>();

            var source = Fixture
                .Build<CreateCategoryDto>()
                .OmitAutoProperties()
                .With(x => x.Title, title)
                .Create();

            // Act
            var result = Mapper.Map<CreateCategoryDto, Category>(source);

            // Asser
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Category>();

            result.Id.ShouldBeOfType<Guid>();

            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe(title);
        }
    }
}
