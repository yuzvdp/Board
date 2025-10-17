using AutoMapper;
using Board.AppServices.Contexts.Categories.Interfaces;
using Board.Contracts.Categories;
using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Categories.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        /// <summary>
        /// Создать category
        /// </summary>
        /// <param name="createCategoryDto" <see cref="CreateCategoryDto"/>></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Guid</returns>
        public Task<Guid> CreateAsync(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateCategoryDto, Category>(createCategoryDto);
            entity.Id = Guid.NewGuid();
            return categoryRepository.AddAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Удалить category
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns>None</returns>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return categoryRepository.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Получить category по id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns>CategoryDto</returns>
        public Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return categoryRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
