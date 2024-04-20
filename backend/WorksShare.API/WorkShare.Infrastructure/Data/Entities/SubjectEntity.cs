namespace WorkShare.Infrastructure.Data.Entities
{
    internal class SubjectEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<WorkEntity> WorkEntities { get; set; }

    }
}
