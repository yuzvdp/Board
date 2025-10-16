using AutoMapper;
using Board.AppServices.Contexts.Adverts.Repository;
using Board.AppServices.Contexts.Adverts.Services;
using Board.Contracts.Adverts;
using Moq;
using Xunit;

namespace Board.Unit.Tests
{
    public class AdvertServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_Should_Call_Repository()
        {
            // Arrange Андреев
            Mock<IAdvertRepository> advertRepositoryMock = new();
            Mock<IMapper> mapperMock = new();

            var service = new AdvertService(advertRepositoryMock.Object, mapperMock.Object);

            var guid = Guid.NewGuid();
            AdvertDto advertDto = new()
            {
                Id = guid,
                Title = "Title",
                CreatedAt = DateTime.Now,
            };

            var token = new CancellationToken();
            advertRepositoryMock
                .Setup(s => s.GetByIdAsync(guid, token))
                .ReturnsAsync(advertDto);

            // Act Алексей
            var result = await service.GetByIdAsync(guid, token);


            // Assert Александрович
            Assert.NotNull(result);
            Assert.Equal(advertDto, result);
            advertRepositoryMock.Verify(s => s.GetByIdAsync(guid, token), Times.Once);
        }
    }
}
