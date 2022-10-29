namespace Techcombank.Entity;

public class Transaction
{
    private String TransID { get; }
    public DateTime Date { get; set; }
    public double Amount { get; set; }
    public string? Type { get; set; }
    public Transaction(double amount, string type)
    {
        this.TransID = Guid.NewGuid().ToString();
        this.Date = DateTime.Now;
        this.Amount = amount;
        this.Type = type;
    }
    public override string ToString() => $"[ID]: {this.TransID}  "
                                       + $"[Amount]: {this.Amount}  "
                                       + $"[Type]: {this.Type}  "
                                       + $"[Date]: {this.Date}\n";
}