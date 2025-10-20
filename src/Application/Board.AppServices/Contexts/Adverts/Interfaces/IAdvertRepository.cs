using Board.AppServices.Specification;
using Board.Contracts.Adverts;
using Board.Contracts.Base;
using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Adverts.Interfaces
{
    public interface IAdvertRepository
    {
        Task<IReadOnlyCollection<AdvertDto>> GetByFilterAsync(AdvertFilterDto filter,
        CancellationToken cancellationToken);

        Task<PaginationCollection<AdvertDto>> FindAsync(Specification<Advert> predicate,
        int page,
        int take,
        CancellationToken cancellationToken);

        Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> AddAsync(Advert advert, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
