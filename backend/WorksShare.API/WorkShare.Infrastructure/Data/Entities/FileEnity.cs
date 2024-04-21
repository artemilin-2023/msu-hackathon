namespace WorkShare.Infrastructure.Data.Entities
{
    internal class FileEnity : BaseEntity
    {
        public string Path { get; set; }
        public WorkEntity WorkEntity { get; set; }
    }
}
