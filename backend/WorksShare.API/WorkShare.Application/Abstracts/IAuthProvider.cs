namespace WorkShare.Application.Abstracts
{
    public interface IAuthProvider
    {
        public Task<int> GetUserIdAsync(string token);
    }
}
