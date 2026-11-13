#!/usr/bin/env dotnet

PlayerCharacter playerOne = new("abc", "Karl", 100, "wizard");
var playerTwo = new PlayerCharacter("cde", "Hannah", 100, "wizard");

// var playerThree = new PlayerCharacter("xyz", "Test", 0, "wizard");

Console.WriteLine($"{playerOne.Health}");
playerOne.Health = -100;
Console.WriteLine($"{playerOne.Health}");
Console.WriteLine($"{playerOne.Name}");
Console.WriteLine($"{PlayerCharacter.CharacterCreated}");

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
            // else if (value > _maxHealth)
            // {
            //     _health = _maxHealth;
            // }
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
