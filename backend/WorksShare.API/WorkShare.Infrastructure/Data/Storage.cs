using Microsoft.AspNetCore.Http;
using Minio;
using Minio.DataModel.Args;
using WorkShare.Application.Abstracts;

namespace WorkShare.Infrastructure.Data
{
    public class Storage : IStorage
    {
        private readonly IMinioClient minioClient;
        private const string bucket = "storage";
        private const int expire = 10 * 60; // 10 min

        public Storage(IMinioClient minioClient)
        {
            this.minioClient = minioClient;
        }

        public async Task<string?> GetDownloadLinkAsync(string file)
        {
            var get = new PresignedGetObjectArgs()
                .WithBucket(bucket)
                .WithObject(file)
                .WithExpiry(expire);

            var link = await minioClient.PresignedGetObjectAsync(get);
            return link;
        }

        public async Task UploadAsync(IFormFile file, string uniqueFileName)
        {
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;

                var putObject = new PutObjectArgs()
                    .WithBucket(bucket)
                    .WithStreamData(stream)
                    .WithObjectSize(file.Length)
                    .WithObject(uniqueFileName)
                    .WithContentType(file.ContentType);

                await minioClient.PutObjectAsync(putObject);
            }
        }

        public async Task RemoveFileAsync(string file)
        {
            var removeArg = new RemoveObjectArgs().WithBucket(bucket).WithObject(file);

            await minioClient.RemoveObjectAsync(removeArg);
        }
    }
}
