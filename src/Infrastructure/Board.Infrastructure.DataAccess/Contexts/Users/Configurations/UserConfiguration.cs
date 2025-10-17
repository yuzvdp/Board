using Board.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Users.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) // Реализация наследуемого интерфейса
        {
            builder.HasKey(x => x.Id);                                      // Ключ
            builder.Property(x => x.Username).HasMaxLength(100).IsRequired();  // Макс длина 100, обязательный
            builder.Property(x => x.Fio).HasMaxLength(200).IsRequired();  // Макс длина 200, обязательный
            builder.HasIndex(a => new { a.CreatedAt, a.Id }).IsUnique();
        }
    }
}
