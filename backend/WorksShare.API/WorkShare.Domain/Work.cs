namespace WorkShare.Domain
{
    public class Work
    {
        public Guid Id { get; private set; }
        public Hierarchy Hierarchy { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string TaskSource { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<string> Files { get; private set; }

        public Work(Guid id, Hierarchy hierarchy, string name, string description, string taskSource, DateTime createdAt, List<string> files)
        {
            if (hierarchy == null) throw new NullReferenceException(nameof(hierarchy));
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
            if (string.IsNullOrEmpty(taskSource)) throw new ArgumentNullException(nameof(taskSource));
            if (files == null) throw new ArgumentNullException();

            Id = id;
            Hierarchy = hierarchy;
            Name = name;
            Description = description;
            TaskSource = taskSource;
            CreatedAt = createdAt;
            Files = files;
        }
    }
}
