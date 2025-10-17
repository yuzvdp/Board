using Board.AppServices.Contexts.Users.Interfaces;
using Board.Contracts.Users;
using Board.Domain.Entities;

namespace Board.Api.Tests.Stubs
{
    public class UserRepositoryStub : IUserRepository
    {
        public Task<Guid> AddAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
