using Board.AppServices.Contexts.Adverts.Repository;
using Board.Contracts.Adverts;

namespace Board.AppServices.Contexts.Adverts.Services
{
    public class AdvertService(IAdvertRepository advertRepository) : IAdvertService
    {
        public Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return advertRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
