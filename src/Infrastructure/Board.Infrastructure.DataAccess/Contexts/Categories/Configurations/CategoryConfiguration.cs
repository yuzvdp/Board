using Board.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Categories.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) // Реализация наследуемого интерфейса
        {
            builder.HasKey(x => x.Id);                                      // Ключ
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();  // Макс длина 100, обязательный
            builder.HasIndex(a => new { a.CreatedAt, a.Id }).IsUnique();    // Индекс
        }
    }
}
