namespace WorkShare.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public User(Guid id, string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            Id = id;
            Name = name;
        }
    }
}
