namespace WorkShare.Infrastructure.Data.Entities
{
    internal class WorkEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public DateTime CreatedAt { get; set; }
        public string WorkType { get; set; }
        public string Subject { get; set; }

        public int UserId { get; set; }
        public List<FileEnity> Files { get; set; }
    }
}
