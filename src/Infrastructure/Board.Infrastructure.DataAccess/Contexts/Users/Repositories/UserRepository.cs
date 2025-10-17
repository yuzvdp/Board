using AutoMapper;
using Board.AppServices.Contexts.Users.Interfaces;
using Board.Contracts.Users;
using Board.Domain.Entities;
using Board.Infrastructure.DataAccess.Repositories;

namespace Board.Infrastructure.DataAccess.Contexts.Users.Repositories
{
    public class UserRepository(
        IRepository<User, ApplicationDbContext> repository,
        IMapper mapper
        ) : IUserRepository
    {
        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(User user, CancellationToken cancellationToken)
        {
            await repository.AddAsync(user, cancellationToken);
            return user.Id;
        }

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return repository.DeleteByIdAsync(id, cancellationToken);
        }

        /// <summary>
        /// Получить пользователя по ИД
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
