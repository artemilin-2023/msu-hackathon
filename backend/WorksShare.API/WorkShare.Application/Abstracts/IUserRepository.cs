using WorkShare.Domain;

namespace WorkShare.Application.Abstracts
{
     public interface IUserRepository
     {
        public Task<User?> GetAsync(Guid userId);
        public Task AddAsync(User user);
        public Task DeleteAsync(Guid userId);
     }
}
