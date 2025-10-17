using AutoMapper;
using Board.AppServices.Contexts.Categories.Interfaces;
using Board.Contracts.Categories;
using Board.Domain.Entities;
using Board.Infrastructure.DataAccess.Repositories;

namespace Board.Infrastructure.DataAccess.Contexts.Categories.Repositories
{
    public class CategoryRepository(
        IRepository<Category, ApplicationDbContext> repository,
        IMapper mapper
        ) : ICategoryRepository
    {

        /// <summary>
        /// Доавбить категорию
        /// </summary>
        /// <param name="category"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(Category category, CancellationToken cancellationToken)
        {
            await repository.AddAsync(category, cancellationToken);
            return category.Id;
        }

        /// <summary>
        /// Удалить категорию
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return repository.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Получить категорию по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
