using Board.Contracts.Adverts;
using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Adverts.Interfaces
{
    public interface IAdvertRepository
    {
        Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> AddAsync(Advert advert, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
