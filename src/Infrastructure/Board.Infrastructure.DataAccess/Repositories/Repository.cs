using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        protected TContext? DbContext;
        protected DbSet<TEntity>? DbSet;

        public Repository(TContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync([id], cancellationToken);
        }
    }
}
