namespace BookLibrary;

class Person
{
    public Person(string name)
    {
        Name = name;
    }

    // public string Name { get; set; } = "";
    public string Name { get; set; } = string.Empty;
    public Guid Id { get; } = Guid.NewGuid();
}
