using Board.AppServices.Contexts.Adverts.Interfaces;
using Board.AppServices.Specification;
using Board.Contracts.Adverts;
using Board.Contracts.Base;
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

        public Task<PaginationCollection<AdvertDto>> FindAsync(Specification<Advert> predicate, int page, int take, CancellationToken cancellationToken)
        {
            var items = new List<AdvertDto>
            {
                new() { Title = "123", },
                new() { Title = "456", }
            };

            var query = items.Where(x => x.Title == "123");

            var total = query.Count();

            var result = query
                .OrderBy(a => a.Id)
                .Skip(take * (page - 1))
                .Take(take)
                //.ProjectTo<AdvertDto>(mapper.ConfigurationProvider)
                .ToArray();

            return Task.FromResult(new PaginationCollection<AdvertDto>
            {
                Items = result.AsReadOnly(),
                Total = total,
                AvailablePages = (int)double.Round((total / (double)take), MidpointRounding.ToPositiveInfinity) - page,
            });
        }

        public Task<IReadOnlyCollection<AdvertDto>> GetByFilterAsync(AdvertFilterDto filter, CancellationToken cancellationToken)
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
