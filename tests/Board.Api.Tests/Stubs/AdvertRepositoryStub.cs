using Board.AppServices.Contexts.Adverts.Interfaces;
using Board.Contracts.Adverts;
using Board.Domain.Entities;

namespace Board.Api.Tests.Stubs
{
    public class AdvertRepositoryStub : IAdvertRepository
    {
        public const string TestGuid = "347b6335-f0bc-492c-8bf7-f8e534cca123";
        public const string TestTitle = "AdvertNumberOne";
        public Task<Guid> AddAsync(Advert advert, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            if (id.ToString() != TestGuid)
            {
                return null;
            }

            return new AdvertDto
            {
                Id = id,
                Title = TestTitle,
                CreatedAt = DateTime.Now,
            };
        }
    }
}
