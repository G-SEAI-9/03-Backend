#!/usr/bin/env dotnet

PlayerCharacter playerOne = new("abc", "Karl", 100, "wizard");
var playerTwo = new PlayerCharacter("cde", "Hannah", 1200, "wizard");

// var playerThree = new PlayerCharacter("xyz", "Test", 0, "wizard");

Console.WriteLine($"{playerOne.Health}");
playerOne.TakeDamage(50);
playerOne.Heal(100);
playerOne.LevelUp();
Console.WriteLine($"{playerOne.Health}");

Console.WriteLine($"{playerTwo.Health}");

Console.WriteLine($"{PlayerCharacter.CharacterCreated}");

// playerOne.Health = -100;
// Console.WriteLine($"{playerOne.Health}");
// Console.WriteLine($"{playerOne.Name}");

// Monster monsterOne = new()
// {
//     Id = "lll",
//     Name = "Monsty",
//     Level = 100,
// };
// Monster monsterOne = new("llm");
// Monster monsterTwo = new("llm", "Monsty");
// Console.WriteLine($"{monsterOne.Id}");
// Console.WriteLine($"{monsterOne.Name}");

class PlayerCharacter
{
    // * constructor
    public PlayerCharacter(string characterId, string name, int maxHealth, string archetype)
    {
        CharacterId = characterId;
        Name = name;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Archetype = archetype;
        Level = 1;

        CharacterCreated++;
    }

    // * methods
    public void TakeDamage(int damageAmount)
    {
        if (damageAmount <= 0)
            return;

        Health -= damageAmount;
        Console.WriteLine($"{Name} took {damageAmount} damage");

        if (!IsAlive)
        {
            Console.WriteLine($"{Name} has been defeated in combat");
        }
    }

    public void Heal(int healAmount)
    {
        if (!IsAlive)
        {
            Console.WriteLine($"Cannot heal {Name} because they are defeated");
            return;
        }
        if (healAmount <= 0)
            return;

        Health += healAmount;
        Console.WriteLine($"{Name} recovered {healAmount} HP");
    }

    public void LevelUp()
    {
        Level++;
        MaxHealth += 20;
        Health = MaxHealth;
        Console.WriteLine($"{Name} reached Level {Level}");
    }

    // * static field
    public static int CharacterCreated = 0;

    // * fields (state)
    private int _health = 100;

    private int _maxHealth;

    // * property
    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Max health must be greater than zero."
                );
            }
            _maxHealth = value;
        }
    }
    public int Health
    {
        get => _health;
        set
        {
            if (value < 0)
            {
                _health = 0;
            }
            else if (value > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health = value;
            }
        }
    }
    public string Name { get; set; }
    public string CharacterId { get; init; }
    public int Level { get; private set; }
    public string Archetype { get; init; }

    // calculated property
    public bool IsAlive => Health > 0;
    public double HealthPercentage => (double)Health / MaxHealth * 100;
}

class Monster
{
    public Monster(string id)
    {
        Id = id;
        Name = "Default Monster";
    }

    public Monster(string id, string name)
    {
        Id = id;
        Name = name;
    }

    // auto-properties (fields werden automatisch generiert)
    public string Id { get; init; }

    public string Name { get; set; }

    public int Level { get; set; }
}
