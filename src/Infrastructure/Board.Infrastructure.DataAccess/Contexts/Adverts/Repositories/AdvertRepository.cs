using AutoMapper;
using Board.AppServices.Contexts.Adverts.Repository;
using Board.AppServices.Exceptions;
using Board.Contracts.Adverts;
using Board.Domain.Entities;
using Board.Infrastructure.DataAccess.Repositories;

namespace Board.Infrastructure.DataAccess.Contexts.Adverts.Repositories
{
    public class AdvertRepository(
        IRepository<Advert, ApplicationDbContext> repository,
        IMapper mapper
        ) : IAdvertRepository
    {
        public async Task<Guid> AddAsync(Advert advert, CancellationToken cancellationToken)
        {
            await repository.AddAsync(advert, cancellationToken);
            return advert.Id;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return repository.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>AdvertDto</returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await repository.GetByIdAsync(id, cancellationToken);

            if (result is null)
            {
                throw new NotFoundException(id.ToString());
            }

            return (AdvertDto?)mapper.ProjectTo<AdvertDto>((IQueryable)result);
        }
    }
}
