using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Repositories
{
    public interface IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
