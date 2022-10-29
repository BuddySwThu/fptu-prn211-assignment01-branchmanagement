namespace Techcombank.Entity;

public class Account
{
    private string AccountNumber { get; }
    public double Balance { get; set; }
    public List<Transaction> Transactions { get; set; }
    public Account(double balance, List<Transaction> transactions)
    {
        this.AccountNumber = Guid.NewGuid().ToString();
        this.Transactions = transactions;
        this.Balance = balance;
    } //only for default application
    public Account(double balance)
    {
        this.AccountNumber = Guid.NewGuid().ToString();
        this.Transactions = new List<Transaction>();
        this.Balance = balance;
    }
    public string ID { get => this.AccountNumber; }
    public override string ToString() => $"[ID]: {this.AccountNumber} "
                                       + $" [Balance]: {this.Balance} "
                                       + $" [Num of transactions]: {this.Transactions?.Count}";
}