using Techcombank.BussinessObject;
using Techcombank.Entity;
using static System.Console;

namespace Techcombank.Utils;

public class Input
{
    public static Branch InputBranch()
    {
        string branchName = Input.GetString("Enter branch name: ");
        Address branchAddress = new Address().InputAddress();

        return new Branch(branchName, branchAddress);
    }
    public static Client InputClient()
    {
        string clientName = Input.GetString("Enter client name: ");
        Address clientAddress = new Address().InputAddress();

        return new Client(clientName, clientAddress);
    }
    public static Account InputAccount() => new(Input.GetDouble("Enter account balance: "));
    public static string GetString(string message)
    {
        Write(message);
        return ReadLine() ?? "";
    }
    public static double GetDouble(string message)
    {
        double result;
        while (true)
        {
            Write(message);
            try
            {
                result = double.Parse(s: ReadLine() ?? "0");
                break;
            }
            catch (Exception) { Printer.InformColor("Invalid input!!! Please try again. . .\n", "DR"); }
        }

        return result;
    }
    public static bool AskContinue(string message)
    {
        while (true)
        {
            Write(message);
            string choice = ReadLine() ?? "";
            if (choice.Equals("y", StringComparison.OrdinalIgnoreCase)) return true;
            else if (choice.Equals("n", StringComparison.OrdinalIgnoreCase)) return false;
            else Printer.InformColor("Invalid input!!! Please try again. . .", "DR");
        }
    }
}