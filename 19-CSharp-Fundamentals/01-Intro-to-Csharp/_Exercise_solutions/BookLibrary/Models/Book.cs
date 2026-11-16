namespace BookLibrary.Models;

public class Book(string title, string author, int year)
{
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
    public int Year { get; set; } = year;

    // public DateOnly Year { get; set; } = year;

    public void DisplayInfo()
    {
        Console.WriteLine($"{Title} by {Author} - {Year}");
    }
}
