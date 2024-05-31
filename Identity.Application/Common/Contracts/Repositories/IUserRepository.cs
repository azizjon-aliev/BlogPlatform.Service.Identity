using System.Linq.Expressions;
using Identity.Domain.Entities;

namespace Identity.Application.Common.Contracts.Repositories;

public interface IUserRepository
{
    public Task<User> AddAsync(User user, CancellationToken cancellationToken);

    public Task<bool> ExistsAsync(Expression<Func<User, bool>> predicate, CancellationToken cancellationToken);

    public Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    public Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    
    public Task<User?> GetByRefreshToken(string refreshToken, CancellationToken cancellationToken);
}