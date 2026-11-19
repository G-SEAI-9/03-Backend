#!/usr/bin/env dotnet

Dictionary<string, int> inventory = [];
inventory.Add("SKU-1001", 50);
inventory.Add("SKU-1002", 12);
inventory.Add("SKU-1003", 0);
inventory["SKU-1004"] = 25; // hinzufügen, wenn key noch nicht vorhanden
inventory["SKU-1001"] = 45; // überschreiben, wenn key noch bereits vorhanden
bool added = inventory.TryAdd("SKU-1001", 217);
Console.WriteLine(added);

// Console.WriteLine($"{inventory["SKU-1005"]}");

string searchSku = "SKU-1002";

if (inventory.ContainsKey(searchSku))
{
    Console.WriteLine($"{inventory[searchSku]}");
}

if (inventory.TryGetValue(searchSku, out int quantity))
{
    Console.WriteLine($"Stock for {searchSku}: {quantity}");
}

inventory.Remove("SKU-1003");
inventory.Remove("SKU-1005");

// foreach (var item in inventory)
// foreach (KeyValuePair<string, int> item in inventory)
foreach (var (key, value) in inventory)
{
    Console.WriteLine($"{key} - {value}");
}

// for (const [key, value] of map)

Dictionary<Person, Address> personToAdress = new()
{
    {
        new Person { Name = "Karl", Id = 1 },
        new Address { Street = "Lindenstrasse" }
    },
};

foreach (KeyValuePair<Person, Address> item in personToAdress)
{
    Console.WriteLine($"{item.Key.Name} - {item.Value.Street}");
}

// Console.WriteLine(personToAdress.ContainsKey(new Person { Name = "Karl", Id = 1 }));

class Person
{
    public string Name { get; set; } = "";
    public int Id { get; set; }
}

class Address
{
    public string Street { get; set; } = "";
}


// Ich suche über eine Id, einen Namen, eine SKU? → Dictionary
// Ich brauche die Reihenfolge oder gehe meistens alles durch? → Liste
