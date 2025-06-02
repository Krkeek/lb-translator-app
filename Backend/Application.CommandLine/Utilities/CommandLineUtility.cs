namespace Application.CommandLine.Utilities;

/// <summary>
/// CommandLineUtility.
/// </summary>
public class CommandLineUtility
{
    /// <summary>
    /// WriteSuccessMessage.
    /// </summary>
    /// <param name="message">The message to display as success.</param>
    public static void WriteSuccessMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{message}");
        Console.ResetColor();
    }

    /// <summary>
    /// WriteFailureMessage.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    /// <param name="reason">The reason of the failure.</param>
    public static void WriteFailureMessage(string message, string reason)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Error.WriteLine($"{message}\n{reason}");
        Console.ResetColor();
    }

    /// <summary>
    /// Writes a formatted title section with separators.
    /// </summary>
    /// <param name="title">The title to display.</param>
    public static void WriteTitle(string title)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 50));
        Console.WriteLine($"🔷  {title}");
        Console.WriteLine(new string('=', 50));
    }
}