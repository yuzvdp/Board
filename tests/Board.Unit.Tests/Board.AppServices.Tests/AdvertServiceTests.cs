using AutoMapper;
using Board.AppServices.Contexts.Adverts.Interfaces;
using Board.AppServices.Contexts.Adverts.Services;
using Board.Contracts.Adverts;
using Moq;

namespace Board.Unit.Tests.Board.AppServices.Tests
{
    public class AdvertServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_Should_Call_Repository()
        {
            // Arrange Andreev
            Mock<IAdvertRepository> advertRepositoryMock = new();
            Mock<IMapper> mapperMock = new();

            var service = new AdvertService(advertRepositoryMock.Object, mapperMock.Object);
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var guid = Guid.NewGuid();

            var article = new AdvertDto();

            advertRepositoryMock
                .Setup(x => x.GetByIdAsync(guid, token))
                .ReturnsAsync(article);

            // Act Aleksey
            var result = await service.GetByIdAsync(guid, token);

            // Assert Aleksandrovich
            Assert.NotNull(result);
            Assert.Equal(article, result);
            advertRepositoryMock.Verify(x => x.GetByIdAsync(guid, token), Times.Once);
        }
    }
}