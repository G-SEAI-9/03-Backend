var day1 = new DaySchedule
{
    Date = new DateOnly(2025, 9, 15),
    Sessions = new List<Session>
    {
        new Session
        {
            Title = "Modern C# Patterns",
            Track = "Backend",
            DurationMinutes = 50,
            Tags = new() { "C#", "Design" },
        },
        new Session
        {
            Title = "LINQ Deep Dive",
            Track = "Backend",
            DurationMinutes = 60,
            Tags = new() { "C#", "LINQ", "Performance" },
        },
        new Session
        {
            Title = "WebAssembly with Blazor",
            Track = "Frontend",
            DurationMinutes = 45,
            Tags = new() { "Blazor", "WASM" },
        },
    },
};

var day2 = new DaySchedule
{
    Date = new DateOnly(2025, 9, 16),
    Sessions = new List<Session>
    {
        new Session
        {
            Title = "APIs at Scale",
            Track = "Backend",
            DurationMinutes = 40,
            Tags = ["API", "Scaling"],
        },
        new Session
        {
            Title = "UX Micro‑interactions",
            Track = "Frontend",
            DurationMinutes = 35,
            Tags = new() { "UX", "Animation" },
        },
        new Session
        {
            Title = "Streaming Data 101",
            Track = "Data",
            DurationMinutes = 55,
            Tags = new() { "Data", "Streams" },
        },
    },
};

var conference = new List<DaySchedule> { day1, day2 };

// Helper sequences for Zip tasks
var rooms = new[] { "Room A", "Room B", "Room C" };
var timeSlots = new[] { "09:00", "10:30", "12:00" };

// # Select

var titles = day1.Sessions.Select(s => s.Title);
foreach (string title in titles)
{
    Console.WriteLine($"{title}");
}

var durations = day1.Sessions.Select(s => s.DurationMinutes);

var titleTrack = day1.Sessions.Select(s => new { s.Title, s.Track });
var sessionCards = day1.Sessions.Select(s => new SessionCard(s.Title, s.DurationMinutes));

var calculations = day1.Sessions.Select(s => new
{
    s.Title,
    MinutesPerTag = s.DurationMinutes / Math.Max(1, s.Tags.Count),
});
foreach (var c in calculations)
{
    Console.WriteLine($"{c.Title} - {c.MinutesPerTag}");
}

// * SelectMany (flattening)

var sessions = conference.SelectMany(d => d.Sessions);
foreach (var el in sessions)
{
    Console.WriteLine($"{el.Title}");
}

foreach (var day in conference)
{
    foreach (var s in day.Sessions)
    {
        Console.WriteLine($"{s.Title}");
    }
}

var allTags = conference.SelectMany(d => d.Sessions).SelectMany(s => s.Tags).Distinct();
foreach (var tag in allTags)
{
    Console.WriteLine($"{tag}");
}

var pairs = conference.SelectMany(d => d.Sessions.Select(s => new { d.Date, s.Title }));

foreach (var el in pairs)
{
    Console.WriteLine($"{el.Date:yyyy-MM-dd} - {el.Title}");
}

// # Zip
Console.WriteLine($"\nZip");

var firstThreeTitles = conference.SelectMany(d => d.Sessions).Select(s => s.Title).Take(3);

var titleRoom = firstThreeTitles.Zip(rooms, (t, r) => $"{t} @ {r}");

foreach (var el in titleRoom)
{
    Console.WriteLine($"{el}");
}

var schedule = firstThreeTitles
    .Zip(rooms, (t, r) => (t, r))
    .Zip(timeSlots, (tr, time) => $"{time} - {tr.r} - {tr.t}");

foreach (var el in schedule)
{
    Console.WriteLine($"{el}");
}

var scheduleThree = conference.SelectMany(d => d.Sessions).Take(3).Zip(rooms, timeSlots);

foreach (var (session, room, time) in scheduleThree)
{
    Console.WriteLine($"{time} - {room} - {session.Title}");
}
