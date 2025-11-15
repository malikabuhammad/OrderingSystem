using Microsoft.EntityFrameworkCore;
using OrderingSystem.Application.Interfaces;
using OrderingSystem.Domain.Entities;
using OrderingSystem.Infrastructure.Persistence;

namespace OrderingSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OrderingDbContext _ctx;

        public UserRepository(OrderingDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<User?> GetByUsernameAsync(string username)
        {
            return _ctx.Users
                .Include(u => u.Roles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddAsync(User user)
        {
            await _ctx.Users.AddAsync(user);
        }

        public Task<Role?> GetRoleAsync(string roleName)
        {
            return _ctx.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }

        public async Task AddRoleToUserAsync(int userId, int roleId)
        {
            var ur = new UserRole(userId, roleId);
            await _ctx.UserRoles.AddAsync(ur);
        }

        public Task SaveAsync()
        {
            return _ctx.SaveChangesAsync();
        }
    }
}
