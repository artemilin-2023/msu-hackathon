namespace WorkShare.Infrastructure.Data.Entities
{
    internal class TaskSource : BaseEntity
    {
        public string Name { get; set; }
        public List<WorkEntity> WorkEntities { get; set; }
    }
}
