using AutoMapper;
using Board.AppServices.Contexts.Users.Interfaces;
using Board.Contracts.Users;
using Board.Domain.Entities;

namespace Board.AppServices.Contexts.Users.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="createUserDto" <see cref="CreateUserDto"/>></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Guid</returns>
        public Task<Guid> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateUserDto, User>(createUserDto);
            entity.Id = Guid.NewGuid();
            return userRepository.AddAsync(entity, cancellationToken);
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns>None</returns>
        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            return userRepository.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <param name="cancellationToken"></param>
        /// <returns>UserDto</returns>
        public Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return userRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}
