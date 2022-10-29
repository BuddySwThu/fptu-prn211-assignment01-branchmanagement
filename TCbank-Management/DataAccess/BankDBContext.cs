using Techcombank.Entity;
using Techcombank.Utils;

namespace Techcombank.DataAccess;

// ReSharper disable once InconsistentNaming
public class TCBDBContext
{
    private static readonly List<Branch> _branchList = new();
    private static readonly TCBDBContext? _instance = null;
    private static readonly object InstanceLock = new();
    private TCBDBContext() { }
    public static TCBDBContext Instance { get { lock (InstanceLock) { return _instance ?? new TCBDBContext(); } } }
    public static List<Branch> GetBranchList => _branchList;


    // ________________Branch_________________
    public void AddBranch(Branch branch) => _branchList.Add(branch);
    public void AddClientsToBranch(string compare, List<Client> clients)
    {
        Branch branch = GetBranch(compare, "id");
        branch.Clients.AddRange(clients);
    }
    public Branch GetBranch(string compare, string which)
    {
        Branch? branch;
        if ("id".Equals(which)) branch = _branchList.SingleOrDefault(b => b.ID == compare);
        else branch = _branchList.SingleOrDefault(b => b.Name.Equals(compare));
        if (branch == null) Printer.InformColor("!S.O.S! Branch not found.", "DR");
        return branch;
    }


    // __________________Client_________________
    public List<Client> GetClientListOfABranch(Branch branch) => _branchList.Where(a => a.Equals(GetBranch(branch.ID, "id")))
                                                                            .SelectMany(b => b.Clients)
                                                                            .ToList();
    public Client GetClientByID(string clientID)
    {
        Client? client = _branchList.SelectMany(b => b.Clients).SingleOrDefault(c => c.ID == clientID);
        if (client == null) Printer.InformColor("!S.O.S! Client not found -id.", "DR");
        return client;
    }
    public Client[] GetClientByName(string clientName)
    {
        Client[]? client = _branchList.SelectMany(b => b.Clients).Where(c => c.Name.Equals(clientName)).ToArray();
        if (client == null) Printer.InformColor("!S.O.S! Client not found -name.", "DR");
        return client;
    }
    public List<Client> GetClientListByBranch(Branch branch) => branch.Clients;
    public double GetTotalBalanceOfEachClient(Client client) => client.Accounts.Sum(a => a.Balance);
    public Client FindClientWithHighestNumberOfTransactions() => _branchList.SelectMany(b => b.Clients)
                                                                            .OrderByDescending(c => c.Accounts.Sum(a => a.Transactions.Count))
                                                                            .First();


    // __________________Account_________________
    public void AddAccountToClient(string clieID, List<Account> accounts)
    {
        Client client = GetClientByID(clieID);
        client.Accounts.AddRange(accounts);
    }
    public void TopupOrWithdrawAccount(Account account, Transaction transaction)
    {
        if (transaction.Type == "D")
        {
            account.Balance += transaction.Amount;
            account.Transactions?.Add(transaction);
            Printer.InformColor("Deposit successfully.", "Gr");
        }
        else
        {
            if (account.Balance - transaction.Amount < 0) throw new Exception("Balance is not enough!");
            account.Balance -= transaction.Amount;
            account.Transactions?.Add(transaction);
            Printer.InformColor("Withdraw successfully.", "Gr");
        }
    }
    public Account GetAccountByAccountNumber(string accountNumber, Branch branchW)
    {
        Account? account = _branchList.Where(a => a.Name.Equals(branchW?.Name))
                                      .SelectMany(b => b.Clients)
                                      .SelectMany(c => c.Accounts)
                                      .SingleOrDefault(a => a.ID == accountNumber);
        if (account == null) Printer.InformColor("!S.O.S! Account not found.", "DR");
        return account;
    }
    public List<Account> FindAllAccountsOfEachCustomerWithBiggestBalance(Client client)
    {
        List<Account> accounts = client.Accounts;
        List<Account> accountsWithBiggestBalance = new();
        foreach (Account account in accounts) if (account.Balance == accounts.Max(a => a.Balance)) accountsWithBiggestBalance.Add(account);

        return accountsWithBiggestBalance;
    }
}