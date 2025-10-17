using Board.Contracts.Users;

namespace Board.AppServices.Contexts.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Guid> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
