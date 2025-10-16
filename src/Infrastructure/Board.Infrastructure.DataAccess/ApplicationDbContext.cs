using Board.Domain.Entities;
using Board.Infrastructure.DataAccess.Contexts.Adverts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Board.Infrastructure.DataAccess
{
    /// <summary>
    /// Контекст приложения
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Таблица объявлений
        /// </summary>
        public DbSet<Advert> Adverts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AdvertConfiguration());
        }
    }
}
