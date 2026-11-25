using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using ContactBookApp.Models;

namespace ContactBookApp.Services;

public class ContactService
{
    private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };
    private readonly string _filePath;

    public ContactService(string filePath)
    {
        _filePath = filePath;
    }

    public void AddContact(Contact contact)
    {
        var contacts = LoadContacts();
        contacts.Add(contact);
        SaveToFile(contacts);
        Console.WriteLine("Contact added.");
    }

    public void ListContacts()
    {
        var contacts = LoadContacts();
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        foreach (var c in contacts)
        {
            Console.WriteLine($"{c.Name} - {c.Email} - {c.Phone}");
        }
    }

    public void GetByName(string name)
    {
        var contacts = LoadContacts();
        var found = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (found is null)
        {
            Console.WriteLine("Contact not found.");
        }
        else
        {
            Console.WriteLine($"{found.Name} – {found.Email} – {found.Phone}");
        }
    }

    public void RemoveByName(string name)
    {
        var contacts = LoadContacts();
        var removed = contacts.RemoveAll(c =>
            c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
        );
        SaveToFile(contacts);

        if (removed > 0)
            Console.WriteLine("Contact removed.");
        else
            Console.WriteLine("No contact found with that name.");
    }

    private List<Contact> LoadContacts()
    {
        // * Ziel:
        // Datei:    contacts.json  (liegt im Feld _filePath)
        // Rückgabe: List<Contact> mit allen gespeicherten Kontakten
        //           (oder leere Liste [], wenn die Datei noch nicht existiert)

        // JSON.parse(localStorage.geTItem(...)) ?? []
        try
        {
            if (!File.Exists(_filePath))
            {
                return [];
            }

            string json = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<Contact>>(json) ?? [];
        }
        catch (Exception ex) when (ex is IOException || ex is JsonException)
        {
            Console.WriteLine($"Error loading contacts: {ex.Message}");
            return [];
        }
    }

    // LoadContacts: Datei → JSON-Text → List<Contact>   (ReadAllText, Deserialize)
    // SaveContacts: List<Contact> → JSON-Text → Datei   (Serialize, WriteAllText)
    private void SaveToFile(List<Contact> contacts)
    {
        // * Ziel:
        // Eingabe:  contacts = komplette Liste (z. B. nach AddContact mit karl)
        // Datei:    contacts.json  (liegt im Feld _filePath)
        // Inhalt:   [
        //             {
        //               "Name": "karl",
        //               "Email": "karl@example.org",
        //               "Phone": "22323-2342-3423"
        //             }
        //           ]

        // localStorage.setItem("contacts", JSON.stringify(contacts))
        try
        {
            string json = JsonSerializer.Serialize(contacts, JsonOptions);

            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"Error saving contacts: {ex.Message}");
        }
    }
}
