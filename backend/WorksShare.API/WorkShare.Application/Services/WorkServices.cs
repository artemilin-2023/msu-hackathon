using Microsoft.AspNetCore.Http;
using System.Collections.ObjectModel;
using WorkShare.Application.Abstracts;
using WorkShare.Domain;

namespace WorkShare.Application.Services
{
    public class WorkServices
    {
        private readonly IWorkRepository workRepository;
        private readonly IStorage storage;

        public WorkServices(IWorkRepository workRepository, IStorage storage)
        {
            this.workRepository = workRepository;
            this.storage = storage;
        }

        public async Task AddWorkAsync(int courcse, string workType, string subject, string name, IFormFileCollection files, int userId)
        {
            var filePaths = new List<string>();

            foreach (var file in files)
            {
                var uniqueFileName = Guid.NewGuid() + file.FileName;
                await storage.UploadAsync(file, uniqueFileName);
                filePaths.Add(uniqueFileName);
            }

            var work = new Work(
                    Guid.NewGuid(),
                    new Hierarchy(workType, subject, courcse),
                    name,
                    DateTime.UtcNow,
                    filePaths,
                    userId
                );

            await workRepository.AddAsync(work);
        }

        public async Task<ReadOnlyCollection<Work>> GetAllWorksAsync(int? course, string name, string subject, string type, int limit)
        {
            var works = workRepository.GetAll();

            if (course != null)
            {
                works = works.Where(w => w.Hierarchy.Course == course);
            }

            if (!string.IsNullOrEmpty(name))
                works = works.Where(w => w.Name.Contains(name));

            if (!string.IsNullOrEmpty(subject))
                works = works.Where(w => w.Hierarchy.Subject == subject);

            if (!string.IsNullOrEmpty(type))
                works = works.Where(w => w.Hierarchy.WorkType == type);

            return works.Take(limit).ToList().AsReadOnly();
        }

        public async Task<Work> GetWorkAsync(Guid id)
        {
            var work = await workRepository.GetAsync(id);
            if (work == null)
                throw new ArgumentNullException(nameof(work));

            var linksTofils = new List<string>();

            foreach (var file in work.Files)
            {
                var link = await storage.GetDownloadLinkAsync(file);
                linksTofils.Add(link);
            }

            work.Files = linksTofils;
            return work;
        }

        public async Task RemoveAsync(Guid id)
        {
            var work = await workRepository.GetAsync(id);
            if (work == null)
                throw new ArgumentNullException(nameof(work));

            foreach (var file in work.Files)
            {
                await storage.RemoveFileAsync(file);   
            }

            await workRepository.DeleteAsync(id);
        }
    }
}
