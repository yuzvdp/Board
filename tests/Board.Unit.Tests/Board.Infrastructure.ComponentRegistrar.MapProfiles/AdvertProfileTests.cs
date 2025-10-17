using AutoFixture;
using AutoMapper;
using Board.Contracts.Adverts;
using Board.Domain.Entities;
using Board.Infrastructure.ComponentRegistrar.MapProfiles;
using Shouldly;

namespace Board.Unit.Tests.Board.Infrastructure.ComponentRegistrar.MapProfiles
{
    public class AdvertProfileTests
    {
        private readonly MapperConfiguration _configurationProvider;

        private IMapper Mapper { get; }
        private Fixture Fixture { get; }

        public AdvertProfileTests()
        {
            _configurationProvider = new MapperConfiguration(delegate (IMapperConfigurationExpression configure)
            {
                configure.AddProfiles(new List<Profile>
                {
                    new AdvertProfile(),
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
        /// Проверка <see cref="AdvertProfile"/>.
        /// </summary>
        [Fact]
        public void AdvertProfile_Check()
        {
            // Arrange
            var title = Fixture.Create<string>();
            var categoryId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            var source = Fixture
                .Build<CreateAdvertDto>()
                .OmitAutoProperties()
                .With(x => x.Title, title)
                .With(x => x.CategoryId, categoryId)
                .With(x => x.UserID, userId)
                .Create();

            // Act
            var result = Mapper.Map<CreateAdvertDto, Advert>(source);

            // Asser
            result.ShouldNotBeNull();
            result.ShouldBeOfType<Advert>();

            result.Id.ShouldBeOfType<Guid>();

            result.Title.ShouldNotBeNull();
            result.Title.ShouldBe(title);

            result.CategoryId.ShouldBeOfType<Guid>();
            result.CategoryId.ShouldBe(categoryId);

            result.UserId.ShouldBeOfType<Guid>();
            result.UserId.ShouldBe(userId);
        }
    }
}
