using System.Diagnostics.Tracing;
using DiaryApp.Models;

namespace DiaryApp.Services;

public class DiaryService
{
    // privates konstantes(!) Feld
    private const string RootFolder = "DiaryEntries";

    public void SaveEntry(DiaryEntry entry)
    {
        // * Ziel:
        // DiaryEntries/2026-11-25/first entry.txt
        //  └── Inhalt: [15:37] lorem ipsum
        try
        {
            string datefolder = Path.Combine(RootFolder, entry.Date.ToString("yyyy-MM-dd"));
            // → "DiaryEntries/2026-11-25"

            if (!Directory.Exists(datefolder))
            {
                Directory.CreateDirectory(datefolder);
            }

            // Ziel: "test/slash" → "test_slash"
            string safeTitle = string.Join('_', entry.Title.Split(Path.GetInvalidFileNameChars()));
            // "test/slash" → ["test", "slash"] → "test_slash"
            // "first entry" → ["first entry"] → "first entry"

            string filePath = Path.Combine(datefolder, safeTitle + ".txt");
            // "DiaryEntries/2026-11-25/first entry.txt"

            // Write line by line with a StreamWriter
            using var writer = new StreamWriter(filePath, append: true);
            writer.WriteLine($"[{DateTime.Now:HH:mm}] {entry.Text}");
            Console.WriteLine($"Entry saved successfully.");
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"Error saving entry: {ex.Message}");
        }
    }

    public string? ReadEntry(string date, string title)
    {
        // * Ziel:
        // Eingabe:  date = "2026-11-25", title = "first entry"
        // Gesucht:  DiaryEntries/2026-11-25/first entry.txt
        // Rückgabe: "[15:46] lorem ipsum"  (oder null, wenn es die Datei nicht gibt)

        try
        {
            string datefolder = Path.Combine(RootFolder, date);
            // → "DiaryEntries/2026-11-25"

            string safeTitle = string.Join('_', title.Split(Path.GetInvalidFileNameChars()));
            // "test/slash" → "test_slash"
            // "first entry" → "first entry"

            string filePath = Path.Combine(datefolder, safeTitle + ".txt");
            // "DiaryEntries/2026-11-25/first entry.txt"

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }

            return null;
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"Error reading entry: {ex.Message}");
            return null;
        }
    }
}
