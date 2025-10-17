using AutoMapper;
using Board.AppServices.Contexts.Categories.Interfaces;
using Board.AppServices.Contexts.Categories.Services;
using Board.Contracts.Categories;
using Moq;

namespace Board.Unit.Tests.Board.AppServices.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task GetByIdAsync_Should_Call_Repository()
        {
            // Arrange Andreev
            Mock<ICategoryRepository> repositoryMock = new();
            Mock<IMapper> mapperMock = new();

            var service = new CategoryService(repositoryMock.Object, mapperMock.Object);
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var guid = Guid.NewGuid();

            var category = new CategoryDto();

            repositoryMock
                .Setup(x => x.GetByIdAsync(guid, token))
                .ReturnsAsync(category);

            // Act Aleksey
            var result = await service.GetByIdAsync(guid, token);

            // Assert Aleksandrovich
            Assert.NotNull(result);
            Assert.Equal(category, result);
            repositoryMock.Verify(x => x.GetByIdAsync(guid, token), Times.Once);
        }
    }
}
