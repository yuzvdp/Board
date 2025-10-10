using Board.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Adverts.Configurations
{
    public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
    {
        public void Configure(EntityTypeBuilder<Advert> builder) // Реализация наследуемого интерфейса
        {
            builder.HasKey(x => x.Id);                                      // Ключ
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();  // Макс длина 200, обязательный
            builder.HasIndex(a => new { a.CreatedAt, a.Id }).IsUnique();    // Индекс
        }
    }
}
