using Board.AppServices.Contexts.Categories.Interfaces;
using Board.Contracts.Categories;
using Board.Domain.Entities;

namespace Board.Api.Tests.Stubs
{
    public class CategoryRepositoryStub : ICategoryRepository
    {
        public Task<Guid> AddAsync(Category category, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
