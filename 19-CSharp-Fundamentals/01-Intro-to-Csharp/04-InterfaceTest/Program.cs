Console.WriteLine($"Hello, World!");

// int total = checked(price * quaility);

public interface IRepo
{
    void Add();
    void Get();
}

class BookRepo : IRepo
{
    public void Add()
    {
        throw new NotImplementedException();
    }

    public void Get()
    {
        throw new NotImplementedException();
    }
}
