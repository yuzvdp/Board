using AutoFixture;
using AutoMapper;
using Board.Contracts.Users;
using Board.Domain.Entities;
using Board.Infrastructure.ComponentRegistrar.MapProfiles;
using Shouldly;

namespace Board.Unit.Tests.Board.Infrastructure.ComponentRegistrar.MapProfiles
{
    public class UserProfileTests
    {
        private readonly MapperConfiguration _configurationProvider;

        private IMapper Mapper { get; }
        private Fixture Fixture { get; }

        public UserProfileTests()
        {
            _configurationProvider = new MapperConfiguration(delegate (IMapperConfigurationExpression configure)
            {
                configure.AddProfiles(new List<Profile>
                {
                    new UserProfile(),
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
        /// Проверка <see cref="UserProfile"/>.
        /// </summary>
        [Fact]
        public void UserProfile_Check()
        {
            // Arrange
            var username = Fixture.Create<string>();
            var fio = Fixture.Create<string>();

            var source = Fixture
                .Build<CreateUserDto>()
                .OmitAutoProperties()
                .With(x => x.Username, username)
                .With(x => x.Fio, fio)
                .Create();

            // Act
            var result = Mapper.Map<CreateUserDto, User>(source);

            // Asser
            result.ShouldNotBeNull();
            result.ShouldBeOfType<User>();

            result.Id.ShouldBeOfType<Guid>();

            result.Username.ShouldNotBeNull();
            result.Username.ShouldBe(username);

            result.Fio.ShouldNotBeNull();
            result.Fio.ShouldBe(fio);
        }
    }
}
