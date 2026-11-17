#!/usr/bin/env dotnet

Dragon dragonOne = new("a", "dOne", 1, 200);
Console.WriteLine(dragonOne.GetType().Name);
Console.WriteLine(dragonOne.FireDmg);

Goblin goblinOne = new("b", "gOne", 1, 200);
goblinOne.TakeDamage(24);

// AbstractMonster monsterOne = new("c", "mOne", 1)

goblinOne.PerformSpecialAbility();
dragonOne.PerformSpecialAbility();

void MonsterAttack(AbstractMonster monster)
{
    monster.PerformSpecialAbility();
    monster.TakeDamage(20);
}

MonsterAttack(dragonOne);
MonsterAttack(goblinOne);

// class Monster
// {
//     public string Id { get; set; }
//     public string Name { get; set; }
//     public int Level { get; set; }
//     public int Health { get; set; }

//     public Monster(string id, string name, int level)
//     {
//         Id = id;
//         Name = name;
//         Level = level;
//         Health = 100 * level;
//     }

//     public void TakeDamage(int damage)
//     {
//         Health -= damage; // Health = Health - damage;
//         Console.WriteLine($"{Name} took {damage} damage");
//     }

//     public void Attack()
//     {
//         Console.WriteLine($"{Name} performs attack");
//     }
// }

// class Dragon : Monster
// {
//     public int FirePower { get; set; }

//     public Dragon(string id, string name, int level, int firePower)
//         : base(id, name, level)
//     {
//         FirePower = firePower;
//     }
// }

// class Goblin : Monster
// {
//     public int StealthRating { get; set; }

//     public Goblin(string id, string name, int level, int stealthRating)
//         : base(id, name, level)
//     {
//         StealthRating = stealthRating;
//     }
// }

public abstract class AbstractMonster(string id, string name, int level)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public int Level { get; set; } = level;
    public int Health { get; protected set; } = 100 * level;

    public abstract string ElementType { get; }

    public abstract void PerformSpecialAbility();

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{Name} healed for {amount}");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage; // Health = Health - damage;
        Console.WriteLine($"{Name} took {damage} damage");
    }
}

class Goblin : AbstractMonster
{
    public Goblin(string id, string name, int level, int stealth)
        : base(id, name, level)
    {
        StealthRating = stealth;
    }

    public int StealthRating { get; set; }

    public override string ElementType => "Poison";

    public override void PerformSpecialAbility()
    {
        Console.WriteLine($"{Name} vanished into the shadows");
    }
}

class Dragon : AbstractMonster
{
    public Dragon(string id, string name, int level, int fireDamage)
        : base(id, name, level)
    {
        FireDmg = fireDamage;
    }

    public int FireDmg { get; set; }

    public override string ElementType => "Air";

    public override void PerformSpecialAbility()
    {
        Console.WriteLine($"{Name} is flying around");
    }
}
