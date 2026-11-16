#!/usr/bin/env dotnet

ActingCool(new Person());
ActingCool(new Animal());

void ActingCool(ICool character)
{
    character.BeingCool();
}

void HealSomething(IHeal thing)
{
    thing.Heal();
}

var bookRepo = new BookRepository();
bookRepo.Add();

var bookDB = new BookDatabaseService();
bookDB.Add();

var menu = new Menu();
menu.AddBook(bookRepo);
menu.AddBook(bookDB);

HealSomething(new Character());
HealSomething(new Drink());

public interface ICool
{
    // public void BeingCool();
    void BeingCool();
}

class Person : ICool, IHeal
{
    public string Name { get; set; }
    public string Age { get; set; }

    public void BeingCool()
    {
        Console.WriteLine($"I am cool!");
    }

    public void Heal()
    {
        throw new NotImplementedException();
    }
}

class Animal : ICool
{
    public void BeingCool()
    {
        Console.WriteLine($"I am cool in an animal style.");
    }
}

public interface IRepository
{
    void Add();
    void Get();
    void Remove();
    void Edit();
}

class BookRepository : IRepository
{
    public void Add()
    {
        Console.WriteLine($"Book added to the list.");
    }

    public void Edit()
    {
        throw new NotImplementedException();
    }

    public void Get()
    {
        throw new NotImplementedException();
    }

    public void Remove()
    {
        throw new NotImplementedException();
    }
}

class BookDatabaseService : IRepository
{
    public void Add()
    {
        Console.WriteLine($"Book added to the database.");
    }

    public void Edit()
    {
        throw new NotImplementedException();
    }

    public void Get()
    {
        throw new NotImplementedException();
    }

    public void Remove()
    {
        throw new NotImplementedException();
    }
}

class Menu
{
    public void Run()
    {
        // while loop mit Menu...
    }

    public void AddBook(IRepository repo)
    {
        repo.Add();
    }
}

public interface IHeal
{
    void Heal();
}

class Character : IHeal
{
    public void Heal()
    {
        Console.WriteLine($"The character casts a healing spell.");
    }
}

class Drink : IHeal
{
    public void Heal()
    {
        Console.WriteLine($"You drink a healing potion.");
    }
}
