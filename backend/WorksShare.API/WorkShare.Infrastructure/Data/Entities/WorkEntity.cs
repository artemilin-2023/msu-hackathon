namespace WorkShare.Infrastructure.Data.Entities
{
    internal class WorkEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public WorkTypeEntity WorkTypeEntity { get; set; }
        public SubjectEntity SubjectEntity { get; set; }
        public TaskSource TaskSource { get; set; }
        public UserEntity UserEntity { get; set; }
        public List<FileEnity> Files { get; set; }
    }
}
