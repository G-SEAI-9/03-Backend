// button.AddEventListener("click", handler)
// onClick={handler}

// * Ziel:
// daily.PublishNews()
//   → "Publishing News"
//   → Karl is reading the news
//   → Hannah is reading the news

// # Events
Newspaper daily = new();

Reader readerOne = new("Karl");
Reader readerTwo = new("Hannah");

// Start:                        daily.News = null (leere Abo-Liste)
// readerOne.SubscribeToNews:    daily.News = [Karl.Read]
readerOne.SubscribetoNews(daily);

// readerTwo.SubscribeToNews:    daily.News = [Karl.Read, Hannah.Read]
readerTwo.SubscribetoNews(daily);

readerOne.SubscribeToSpecialNews(daily);
readerTwo.SubscribeToSpecialNews(daily);

// daily.News -= (sender, e) => Console.WriteLine($"hello");
readerOne.UnsubscribeFromSpecialNews(daily);

// daily.PublishNews():          ruft erst Karl.Read(...), dann Hannah.Read(...) auf
daily.PublishNews();
daily.PublishSpecialNews("Orca attacks sailing boat.");

// # Typen: Events
class Newspaper
{
    // * EventHandler → e ist das leere EventArgs
    // * EventHandler<SpecialNewsEventArgs> → e ist unser SpecialNewsEventArgs (mit e.Content)

    // * 1. Event-Deklaration public event EventHandler? News;
    public event EventHandler? News; // Abo-Liste
    public event EventHandler<SpecialNewsEventArgs>? SpecialNews;

    // * 2. protected virtual Methode zum Auslösen (OnNews)
    // Schema: `protected virtual void On<EventName>(EventArgs e)`
    protected virtual void OnNews(EventArgs e)
    {
        News?.Invoke(this, e); // der eigentliche Auslöse-Knopf
    }

    protected virtual void OnSpecialNews(SpecialNewsEventArgs e)
    {
        SpecialNews?.Invoke(this, e);
    }

    // * 3. Eine Methode, die das Event triggert (PublishNews)
    public void PublishNews() //hier passiert etwas im Programm und der auslöse "Knopf" wird gedrückt.
    {
        Console.WriteLine($"Publish News");
        OnNews(EventArgs.Empty);
    }

    public void PublishSpecialNews(string content)
    {
        OnSpecialNews(new SpecialNewsEventArgs(content));
    }
}

// * Wie Publisher und Subscriber zusammenpassen:
// Publisher ruft auf:   News?.Invoke( this,            EventArgs.Empty );
//                                       ↓                    ↓
// Subscriber bekommt:   void Read   ( object? sender,  EventArgs e )

class Reader
{
    public string Name { get; set; } = string.Empty;

    public Reader(string name)
    {
        Name = name;
    }

    public void SubscribetoNews(Newspaper n)
    {
        n.News += Read;
    }

    public void SubscribeToSpecialNews(Newspaper n)
    {
        n.SpecialNews += ReadSpecialNews;
    }

    // Handler-Signatur: public void Name(object? sender, EventArgs e)
    public void Read(object? sender, EventArgs e)
    {
        Console.WriteLine($"{Name} is reading the news");
        // Console.WriteLine($"{Name} is reading the news ({sender})");
    }

    public void ReadSpecialNews(object? sender, SpecialNewsEventArgs e)
    {
        Console.WriteLine($"{Name} is reading about {e.Content}");
    }

    public void UnsubscribeFromSpecialNews(Newspaper n)
    {
        n.SpecialNews -= ReadSpecialNews;
    }
}

// Konvention: <EventName>EventArgs
sealed class SpecialNewsEventArgs : EventArgs
{
    public string Content { get; }

    public SpecialNewsEventArgs(string content)
    {
        Content = content;
    }
}
