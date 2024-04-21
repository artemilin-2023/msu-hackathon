using WorkShare.Domain;

namespace WorkShare.Application.Abstracts
{
     public interface IUserRepository
     {
        public Task<User?> GetAsync(int userId);
        public Task AddAsync(User user);
        public Task DeleteAsync(int userId);
     }
}
