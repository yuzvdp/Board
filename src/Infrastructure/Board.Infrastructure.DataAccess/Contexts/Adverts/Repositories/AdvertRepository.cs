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
