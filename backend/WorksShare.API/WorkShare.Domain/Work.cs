namespace WorkShare.Domain
{
    public class Work
    {
        public Guid Id { get; private set; }
        public Hierarchy Hierarchy { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<string> Files { get; set; }
        public int UserId { get; private set; }

        public Work(Guid id, Hierarchy hierarchy, 
            string name, DateTime createdAt, List<string> files, int userId)
        {
            if (hierarchy == null) throw new NullReferenceException(nameof(hierarchy));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (files == null) throw new ArgumentNullException();

            Id = id;
            Hierarchy = hierarchy;
            Name = name;
            CreatedAt = createdAt;
            Files = files;
            UserId = userId;
        }
    }
}
