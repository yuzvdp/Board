using Board.Contracts.Categories;

namespace Board.AppServices.Contexts.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
