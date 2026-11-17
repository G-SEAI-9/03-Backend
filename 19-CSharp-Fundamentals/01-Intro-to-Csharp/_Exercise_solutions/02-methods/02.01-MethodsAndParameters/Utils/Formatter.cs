namespace Utils;

public class Formatter
{
    public static string FormatNumber(int n) => $"Number: {n}";

    public static string FormatNumber(double d) => $"Double: {d:0.00}"; // 2.5 -> 2.50 || 3.14159 -> 3.14

    public static string FormatMessage(string text, int repeat = 1)
    {
        string result = text;
        for (int i = 1; i < repeat; i++)
        {
            result += $" {text}";
        }

        return result;
    }
}
