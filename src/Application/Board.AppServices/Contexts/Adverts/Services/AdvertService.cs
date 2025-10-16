using AutoMapper;
using Board.AppServices.Contexts.Adverts.Repository;
using Board.Contracts.Adverts;
using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Adverts.Services
{
    public class AdvertService(IAdvertRepository advertRepository, IMapper mapper) : IAdvertService
    {
        public Task<Guid> CreateAsync(CreateAdvertDto createAdvertDto, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateAdvertDto, Advert>(createAdvertDto);
            entity.Id = Guid.NewGuid();
            return advertRepository.AddAsync(entity, cancellationToken);
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return advertRepository.DeleteAsync(id, cancellationToken);
        }

        public Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return advertRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
