using Board.Contracts.Categories;
using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Categories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> AddAsync(Category category, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
