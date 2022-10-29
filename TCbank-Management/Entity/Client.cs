using Techcombank.BussinessObject;

namespace Techcombank.Entity;

public class Client
{
    private string ClieID { get; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public List<Account> Accounts { get; set; }
    public Client(string name, Address address, List<Account> accounts)
    {
        this.ClieID = Guid.NewGuid().ToString();
        this.Accounts = accounts;
        this.Name = name;
        this.Address = address;
    } //only for default application
    public Client(string name, Address address)
    {
        this.ClieID = Guid.NewGuid().ToString();
        this.Accounts = new List<Account>();
        this.Name = name;
        this.Address = address;
    }
    public string ID { get => this.ClieID; }
    public override string ToString() => $"[ID]: {this.ClieID}  "
                                       + $"[Name]: {this.Name}  "
                                       + this.Address.ToString();
}