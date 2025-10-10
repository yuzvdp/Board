using Board.Contracts.Adverts;

namespace Board.AppServices.Contexts.Adverts.Repository
{
    public interface IAdvertRepository
    {
        Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
