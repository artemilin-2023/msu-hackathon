using WorkShare.Domain;

namespace WorkShare.Application.Abstracts
{
    public interface IWorkRepository
    {
        public IEnumerable<Work> GetAll();
        public Task<Work?> GetAsync(Guid workId);
        public Task AddAsync(Work work);
        public IEnumerable<Work> GetAllByUserId(int userId);
        public Task DeleteAsync(Guid workId);
    }
}
