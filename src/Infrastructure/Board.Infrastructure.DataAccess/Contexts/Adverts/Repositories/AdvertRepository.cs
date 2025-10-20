using AutoMapper;
using AutoMapper.QueryableExtensions;
using Board.AppServices.Contexts.Adverts.Interfaces;
using Board.AppServices.Specification;
using Board.Contracts.Adverts;
using Board.Contracts.Base;
using Board.Domain.Entities;
using Board.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Contexts.Adverts.Repositories
{
    public class AdvertRepository(
        IRepository<Advert, ApplicationDbContext> repository,
        IMapper mapper
        ) : IAdvertRepository
    {

        /// <summary>
        /// Создать advert
        /// </summary>
        /// <param name="advert" <see cref="Advert"/>></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(Advert advert, CancellationToken cancellationToken)
        {
            await repository.AddAsync(advert, cancellationToken);
            return advert.Id;
        }

        /// <summary>
        /// Удалить advert по id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return repository.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Получить advert по id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns>AdvertDto</returns>       
        public async Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll().Where(x => x.Id == id)
                .Include(u => u.User)
                .Include(c => c.Category)
                .ProjectTo<AdvertDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            // маппер делает это
            //var advertDto = new AdvertDto() 
            //{
            //    Id = result.Id,
            //    CreatedAt = result.CreatedAt,
            //    Title = result.Title,
            //    CategoryId = result.CategoryId,
            //    CategoryDto = new CategoryDto
            //    {
            //        Id = result.Category.Id,
            //        Title = result.Category.Title,
            //        CreatedAt = result.Category.CreatedAt
            //    },
            //    UserId = result.UserId,
            //    UserDto = new UserDto
            //    {
            //        Id = result.User.Id,
            //        Username = result.User.Username,
            //        Fio = result.User.Fio,
            //        CreatedAt = result.User.CreatedAt
            //    }
            //};            

            return result;
        }

        /// <summary>
        /// Поиск с пагинацией
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PaginationCollection<AdvertDto>> FindAsync(Specification<Advert> predicate,
            int page,
            int take,
            CancellationToken cancellationToken)
        {
            var query = repository.GetAll().Where(predicate);

            var total = await query.CountAsync(cancellationToken);

            var result = await query
                .OrderBy(a => a.Id)
                .Skip(take * (page - 1))
                .Take(take)
                .ProjectTo<AdvertDto>(mapper.ConfigurationProvider)
                .ToArrayAsync(cancellationToken);

            return new PaginationCollection<AdvertDto>
            {
                Items = result.AsReadOnly(),
                Total = total,
                AvailablePages = (int)double.Round((total / (double)take), MidpointRounding.ToPositiveInfinity) - page,
            };
        }

        /// <summary>
        /// Фильтрация по наименованию
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<AdvertDto>> GetByFilterAsync(AdvertFilterDto filter, CancellationToken cancellationToken)
        {
            var adverts = repository.GetAll();

            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                adverts = adverts.Where(a => a.Title.Contains(filter.Title));
            }

            return await adverts
                .ProjectTo<AdvertDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
