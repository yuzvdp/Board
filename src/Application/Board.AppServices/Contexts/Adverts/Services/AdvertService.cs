using AutoMapper;
using Board.AppServices.Contexts.Adverts.Interfaces;
using Board.AppServices.Specification;
using Board.Contracts.Adverts;
using Board.Contracts.Base;
using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Adverts.Services
{
    public class AdvertService(IAdvertRepository advertRepository, IMapper mapper) : IAdvertService
    {
        /// <summary>
        /// Создать advert
        /// </summary>
        /// <param name="createAdvertDto" <see cref="CreateAdvertDto"/>></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Guid> CreateAsync(CreateAdvertDto createAdvertDto, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateAdvertDto, Advert>(createAdvertDto);
            entity.Id = Guid.NewGuid();
            return advertRepository.AddAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Удалить advert
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return advertRepository.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Поиск по предикату с пагинацией
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<PaginationCollection<AdvertDto>> FindAsync(Specification<Advert> predicate,
            int page,
            int take,
            CancellationToken cancellationToken)
        {
            return advertRepository.FindAsync(predicate, page, take, cancellationToken);
        }

        /// <summary>
        /// Фильтрация
        /// </summary>
        /// <param name="filter">AdvertFilterDto</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IReadOnlyCollection<AdvertDto>> GetByFilterAsync(AdvertFilterDto filter, CancellationToken cancellationToken)
        {
            return advertRepository.GetByFilterAsync(filter, cancellationToken);
        }


        /// <summary>
        /// Получить advert по id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return advertRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
