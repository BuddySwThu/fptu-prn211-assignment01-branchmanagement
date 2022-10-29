using static System.Console;

namespace Techcombank.Utils;

public class Printer
{
    public static void InformColor(string message, string color)
    {
        if (color.Equals("DR")) ForegroundColor = ConsoleColor.DarkRed;
        else if (color.Equals("Gr")) ForegroundColor = ConsoleColor.Green;
        else if (color.Equals("Yl")) ForegroundColor = ConsoleColor.DarkYellow;
        else if (color.Equals("Mg")) ForegroundColor = ConsoleColor.Magenta;
        else if (color.Equals("Bl")) ForegroundColor = ConsoleColor.Blue;
        else ForegroundColor = ConsoleColor.Cyan;
        WriteLine(message);
        ResetColor();
    }
}
