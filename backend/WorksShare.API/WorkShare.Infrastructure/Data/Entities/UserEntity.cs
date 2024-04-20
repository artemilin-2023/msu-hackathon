namespace WorkShare.Infrastructure.Data.Entities
{
    internal class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public List<WorkEntity> WorkEntities { get; set; }
    }
}
