using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Repositories
{
    public interface IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
