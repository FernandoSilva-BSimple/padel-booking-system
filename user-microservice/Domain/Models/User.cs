public class User : IUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public User(string name, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
    }

    public User(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public User() { }
}