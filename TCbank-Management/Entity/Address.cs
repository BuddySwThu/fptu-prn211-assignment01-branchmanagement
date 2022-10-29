using Techcombank.Utils;
using static System.Console;

namespace Techcombank.BussinessObject;

public class Address
{
    public string? Street { get; set; }
    public string? Ward { get; set; }
    public string? City { get; set; }
    public Address() { }
    public Address(string? street, string? ward, string? city)
    {
        this.Street = street;
        this.Ward = ward;
        this.City = city;
    } //only for default application
    public override string ToString() => $"[Address]: {this.Street}, {this.Ward}, {this.City}";
    public Address InputAddress()
    {
        WriteLine("\t</> Input address </>");
        this.Street = InputNonBlankString("+ Street: ");
        this.Ward = InputNonBlankString("+ Ward: ");
        this.City = InputNonBlankString("+ City: ");

        return this;
    }
    private static string InputNonBlankString(string msg)
    {
        string inputted;
        do
        {
            Write(msg);
            inputted = ReadLine()?.Trim() ?? ". . . .";
            if (inputted.Equals(""))
            {
                Printer.InformColor("Input value must be non-blank string!!!\t" + "Please try again. . .\n", "DR");
            }
        } while (inputted.Equals(""));

        return inputted;
    }
}
