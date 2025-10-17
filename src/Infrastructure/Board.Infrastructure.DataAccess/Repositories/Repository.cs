using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// Дженерик репозиторий
    /// </summary>
    /// <typeparam name="TEntity">Сущность</typeparam>
    /// <typeparam name="TContext">Контекст</typeparam>
    public class Repository<TEntity, TContext> : IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    {
        protected TContext? DbContext;
        protected DbSet<TEntity>? DbSet;

        /// <summary>
        /// Конструктор) так ведь?)
        /// </summary>
        /// <param name="dbContext">Контекст <see cref="ApplicationDbContext"></param>
        public Repository(TContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        /// <summary>
        /// Добавить сущность
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>      
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>     
        public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            if (entity != null)
            {
                DbSet.Remove(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <returns>IQueryable</returns>    
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// Получить сущность по Id
        /// </summary>
        /// <param name="id">Id идентификатор</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Entity</returns>
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbSet.FindAsync(id, cancellationToken);
        }
    }
}
