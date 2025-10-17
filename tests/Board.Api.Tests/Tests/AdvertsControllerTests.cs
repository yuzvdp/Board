using Board.Api.Tests.Stubs;
using Board.Contracts.Adverts;
using Shouldly;
using System.Net;
using System.Net.Http.Json;

namespace Board.Api.Tests.Tests
{
    public class AdvertsControllerTests(TestWebAppFactory application) : IClassFixture<TestWebAppFactory>
    {
        [Fact]
        public async Task GetById_Should_Return_Success()
        {
            // arrange
            var httpClient = application.CreateClient();
            var id = AdvertRepositoryStub.TestGuid;

            // act
            var response = await httpClient.GetAsync($"api/Adverts/{id}", CancellationToken.None);
            var advertDto = await response.Content.ReadFromJsonAsync<AdvertDto>(CancellationToken.None);

            // assert
            response.StatusCode.ShouldBe(HttpStatusCode.OK);

            advertDto.ShouldNotBeNull();
            advertDto.Id.ToString().ShouldBe(id);
            advertDto.Title.ShouldBe(AdvertRepositoryStub.TestTitle);
        }

        [Fact]
        public async Task GetById_NotExists_Should_Return_NotFound()
        {
            // arrange
            var httpClient = application.CreateClient();
            var id = Guid.NewGuid();

            // act
            var response = await httpClient.GetAsync($"api/Adverts/{id}", CancellationToken.None);
            //var errorDto = await response.Content.ReadFromJsonAsync<ErrorDto>(CancellationToken.None);

            // assert
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);

            //errorDto.ShouldNotBeNull();
            //errorDto.Message.ShouldBe($"Сущность с идентификатором {id} не была найдена.");
        }
    }
}
