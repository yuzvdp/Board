using Board.Contracts.Adverts;

namespace Board.AppServices.Contexts.Adverts.Services
{
    public interface IAdvertService
    {
        Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreateAdvertDto createAdvertDto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
