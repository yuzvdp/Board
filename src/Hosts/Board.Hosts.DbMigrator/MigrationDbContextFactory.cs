using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Board.Hosts.DbMigrator
{
    /// <summary>
    /// Создаем фабрику
    /// скопировано с гита*
    /// почитано тут
    /// https://metanit.com/sharp/efcore/2.2.php
    /// </summary>
    public class MigrationDbContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
    {
        /// <summary>
        /// Создание контекста
        /// </summary>
        /// <param name="args">Нет параметров</param>
        /// <returns></returns>
        public MigrationDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("ConnectionString");

            var contextBuilder = new DbContextOptionsBuilder<MigrationDbContext>();
            contextBuilder.UseNpgsql(connectionString);
            return new MigrationDbContext(contextBuilder.Options);
        }
    }
}
