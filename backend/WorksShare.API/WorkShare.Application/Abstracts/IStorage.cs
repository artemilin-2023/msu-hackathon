using Microsoft.AspNetCore.Http;

namespace WorkShare.Application.Abstracts
{
    public interface IStorage
    {
        public Task UploadAsync(IFormFile stream, string uniqueFileName);
        public Task<string?> GetDownloadLinkAsync(string path);
        public Task RemoveFileAsync(string file);
    }
}