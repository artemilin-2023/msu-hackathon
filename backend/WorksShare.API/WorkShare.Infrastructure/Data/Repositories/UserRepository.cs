using Microsoft.EntityFrameworkCore;
using WorkShare.Application.Abstracts;
using WorkShare.Domain;
using WorkShare.Infrastructure.Data.Mappers;

namespace WorkShare.Infrastructure.Data.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DataContext database;

        public UserRepository(DataContext database)
        {
            this.database = database;
        }

        public async Task AddAsync(User user)
        {
            var entity = user.Map();
            await database.Users.AddAsync(entity);
            await database.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var entity = await database.Users.FirstAsync(u => u.Id == userId);
            database.Users.Remove(entity);
            await database.SaveChangesAsync();
        }

        public async Task<User?> GetAsync(int userId)
        {
            var entity = await database.Users.FirstOrDefaultAsync(u => u.Id == userId);
            return entity?.Map();
        }
    }
}
