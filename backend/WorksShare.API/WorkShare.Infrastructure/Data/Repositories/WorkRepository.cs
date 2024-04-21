using Microsoft.EntityFrameworkCore;
using System.Data;
using WorkShare.Application.Abstracts;
using WorkShare.Domain;
using WorkShare.Infrastructure.Data.Entities;
using WorkShare.Infrastructure.Data.Mappers;

namespace WorkShare.Infrastructure.Data.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        private readonly DataContext database;

        public WorkRepository(DataContext database)
        {
            this.database = database;
        }

        public async Task AddAsync(Work work)
        {
            var entity = work.Map();
            var files = new List<FileEnity>();

            foreach (var file in work.Files)
            {
                var fileEntity = new FileEnity()
                {
                    Id = Guid.NewGuid(),
                    Path = file,
                    WorkEntity = entity
                };

                files.Add(fileEntity);
                await database.Files.AddAsync(fileEntity);
            }
            entity.Files = files;

            await database.Works.AddAsync(entity);

            await database.SaveChangesAsync();
        }

        public IEnumerable<Work> GetAll()
        {
            var entities = database.Works.Include(w => w.Files);
            return entities.Select(w => w.Map());
        }

        public IEnumerable<Work> GetAllByUserId(int userId)
        {
            var entities = database.Works
                .Include(w => w.Files)
                .Where(w => w.UserId == userId);

            return entities.Select(w => w.Map());
        }

        public async Task<Work?> GetAsync(Guid workId)
        {
            var entity = await database.Works
                .Include(w => w.Files)
                .FirstOrDefaultAsync(w => w.Id == workId);

            return entity?.Map();            
        }

        public async Task DeleteAsync(Guid workId)
        {
            var entity = await database.Works
                .Include(w => w.Files)
                .FirstAsync(w => w.Id == workId);

            database.Works.Remove(entity);
            await database.SaveChangesAsync();
        }
    }
}
