using System.Diagnostics.Tracing;

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
            Tags = new() { "API", "Scaling" },
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
