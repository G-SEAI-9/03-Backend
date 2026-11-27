using BookShelf.Models;

namespace BookShelf.Services;

public class Shelf(List<Book> books, Action<string> log)
{
    // field
    private readonly List<Book> _books = books;
    private readonly Action<string> _log = log;

    // Methods

    // * Ziel (Find):
    // Rein:   Func<Book, bool> filter   (z. B. book => book.Price < 15.00m)
    // Ablauf: jedes Buch mit filter(book) prüfen → Treffer sammeln → _log("Find: 3 of 5 books matched")
    // Raus:   List<Book> mit allen Treffern

    public List<Book> Find(Func<Book, bool> filter)
    {
        // var matches = new List<Book>();

        // foreach (var book in _books)
        // {
        //     if (filter(book))
        //     {
        //         matches.Add(book);
        //     }
        // }
        // // Find: 3 of 5 books matched
        // _log($"Find: {matches.Count} of {_books.Count} books matched");
        // return matches;

        var matches = _books.Where(filter).ToList();

        _log($"Find: {matches.Count} of {_books.Count} books matched");
        return matches;
    }

    public decimal PriceFor(Book book, Func<decimal, decimal> pricing)
    {
        decimal price = pricing(book.Price);
        return Math.Round(price, 2);
    }

    public decimal Total(Func<decimal, decimal> pricing)
    {
        decimal total = 0m;
        foreach (var book in _books)
        {
            total += PriceFor(book, pricing);
        }
        // Total: 74.49 for 5 books
        _log($" Total: {total:F2} for {_books.Count} books");
        return total;
    }
}
