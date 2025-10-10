using Board.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Board.Hosts.DbMigrator
{
    /// <summary>
    /// Контекст ДБ для мигратора
    /// </summary>
    public class MigrationDbContext : ApplicationDbContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
