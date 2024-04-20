namespace WorkShare.Infrastructure.Data.Entities
{
    internal class FileEnity : BaseEntity
    {
        public string File { get; set; }
        public WorkEntity WorkEntity { get; set; }
    }
}
