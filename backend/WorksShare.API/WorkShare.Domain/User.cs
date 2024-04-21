namespace WorkShare.Domain
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public User(int id, string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");

            Id = id;
            Name = name;
        }
    }
}
