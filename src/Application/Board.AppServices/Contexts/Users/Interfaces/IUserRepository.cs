using Board.Contracts.Users;
using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> AddAsync(User user, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
