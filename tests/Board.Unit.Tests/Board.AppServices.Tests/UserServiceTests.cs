using AutoMapper;
using Board.AppServices.Contexts.Users.Interfaces;
using Board.AppServices.Contexts.Users.Services;
using Board.Contracts.Users;
using Moq;

namespace Board.Unit.Tests.Board.AppServices.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_Should_Call_Repository()
        {
            // Arrange Andreev
            Mock<IUserRepository> userRepositoryMock = new();
            Mock<IMapper> mapperMock = new();

            var service = new UserService(userRepositoryMock.Object, mapperMock.Object);
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var guid = Guid.NewGuid();

            var user = new UserDto();

            userRepositoryMock
                .Setup(x => x.GetByIdAsync(guid, token))
                .ReturnsAsync(user);

            // Act Aleksey
            var result = await service.GetByIdAsync(guid, token);

            // Assert Aleksandrovich
            Assert.NotNull(result);
            Assert.Equal(user, result);
            userRepositoryMock.Verify(x => x.GetByIdAsync(guid, token), Times.Once);
        }
    }
}
