using WorkShare.Domain;
using WorkShare.Infrastructure.Data.Entities;

namespace WorkShare.Infrastructure.Data.Mappers
{
    internal static class WorkMapper
    {
        public static WorkEntity Map(this Work work)
        {
            return new WorkEntity()
            {
                Id = work.Id,
                Name = work.Name,
                Course = work.Hierarchy.Course,
                CreatedAt = work.CreatedAt,
                WorkType = work.Hierarchy.WorkType,
                Subject = work.Hierarchy.Subject,
                UserId = work.UserId
            };
        }

        public static Work Map(this WorkEntity entity)
        {
            return new Work(
                entity.Id,
                new Hierarchy(entity.WorkType, entity.Subject, entity.Course),
                entity.Name,
                entity.CreatedAt,
                entity.Files.Select(f => f.Path).ToList(),
                entity.UserId);
        }
    }
}
