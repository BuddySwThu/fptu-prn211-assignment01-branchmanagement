using Techcombank.BussinessObject;

namespace Techcombank.Entity;

public class Branch
{
    private string BranchID { get; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public List<Client> Clients { get; set; }
    public Branch(string name, Address address, List<Client> clients)
    {
        this.BranchID = Guid.NewGuid().ToString();
        this.Clients = clients;
        this.Name = name;
        this.Address = address;
    } //only for default demo application
    public Branch(string name, Address address)
    {
        this.BranchID = Guid.NewGuid().ToString();
        this.Clients = new List<Client>();
        this.Name = name;
        this.Address = address;
    }
    public string ID { get => this.BranchID; }
    public override string ToString() => $"/ [ID]: {this.BranchID}  "
                                       + $"[Name]: {this.Name}  "
                                       + this.Address.ToString();
}