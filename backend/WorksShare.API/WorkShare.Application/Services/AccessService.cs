using WorkShare.Application.Abstracts;

namespace WorkShare.Application.Services
{
    public class AccessService
    {
        public const string TokenName = "Authorization";

        private readonly IAuthProvider authProvider;
        private readonly IWorkRepository workRepository;

        public AccessService(IAuthProvider authProvider, IWorkRepository workRepository)
        {
            this.authProvider = authProvider;
            this.workRepository = workRepository;
        }

        public async Task<bool> HasAccessAsync(string token, Guid workId)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            var userId = await authProvider.GetUserIdAsync(token);
            var work = await workRepository.GetAsync(workId);

            return work.UserId == userId;
        }

        public async Task<int> GetUserIdAsync(string token)
        {
            return await authProvider.GetUserIdAsync(token);
        }
    }
}
