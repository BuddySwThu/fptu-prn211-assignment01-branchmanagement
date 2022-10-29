using Techcombank.Entity;
using Techcombank.Repository;
using static System.Console;

namespace Techcombank.Utils;

public class Menu
{
    public string Title { get; set; }
    public List<string> Options { get; set; }
    public Menu(string title, List<string> options)
    {
        this.Title = title;
        this.Options = options;
    }
    public void Display()
    {
        WriteLine();
        Printer.InformColor(Title, "Bl");
        for (int i = 0; i < Options.Count; i++) Console.WriteLine($"{i + 1} - {Options[i]}");
    }
    public int GetChoice()
    {
        int choice;
        while (true)
        {
            Write("\n<Enter your choice/>  :  ");
            try
            {
                choice = int.Parse(s: ReadLine() ?? "0");
                if (choice > 0 && choice <= Options.Count) break;
                else Printer.InformColor("Invalid choice!!! Please try again. . .", "DR");
            }
            catch (Exception ex) { Printer.InformColor(ex.Message.ToString(), "DR"); }
        }

        return choice;
    }


    //---------------------------------------------------------------------------------------------------------------------//


    private static readonly IBankRepository _bankRepository = new BankRepository();
    public void CreateNewBranch()
    {
        Branch _branch = Input.InputBranch();
        _bankRepository.AddBranch(_branch);
        Menu _branchMenu = new(_branch.Name.ToUpperInvariant() + "-branch management system",
                               new List<string> { "Add clients to branch", "Add accounts to client", "Exit" });
        while (true)
        {
            _branchMenu.Display();
            int choice = _branchMenu.GetChoice();
            switch (choice)
            {
                case 1: AddClientToBranch(_branch); break;
                case 2: AddAccountToClient(_branch); break;
            }
            if (choice == _branchMenu.Options.Count) { break; }
        }
    }
    public void AddClientToBranch(Branch branch)
    {
        List<Client> clients = new();
        while (true)
        {
            clients.Add(Input.InputClient());
            if (!Input.AskContinue("\nDo you want to add more client? (y/n) "))
            {
                WriteLine("\nRecently added clients:\n" + String.Join(System.Environment.NewLine, clients));
                _bankRepository.AddClientToBranch(branch.ID, clients);
                break;
            }
        }
    }
    public void AddAccountToClient(Branch branch)
    {
        List<Account> accounts = new();
        if (GetClientListOfABranch(branch) == 0) return;
        string clieID = Input.GetString("\nEnter client id: ");
        try
        {
            while (true)
            {
                accounts.Add(Input.InputAccount());
                Printer.InformColor("\nAccount added successfully!", "Gr");
                if (!Input.AskContinue("\nDo you want to add more account? (y/n) "))
                {
                    WriteLine("\nRecently added accounts:\n" + String.Join(System.Environment.NewLine, accounts));
                    _bankRepository.AddAccountToClient(clieID, accounts);
                    break;
                }
            }
        }
        catch (Exception e) { WriteLine(e.Message); }
    }
    public void PrintouClientInfo()
    {
        try
        {
            string name = Input.GetString("\nEnter client name: ");
            Client[]? clie = _bankRepository.GetClientByName(name).ToArray();
            if (clie.Length == 0)
            {
                Printer.InformColor("Something went wrong!", "DR");
                return;
            }
            foreach (dynamic x in clie) WriteLine("\t" + x);
        }
        catch (Exception ex) { Printer.InformColor(ex.Message, "DR"); }
    }
    public void DepositOrWithdraw()
    {
        try
        {
            Branch brand;
            while (true)
            {
                brand = _bankRepository.GetBrand(Input.GetString("Enter branch name: "), "name");
                if (brand != null) break;
            }
            Account account;
            while (true)
            {
                account = _bankRepository.GetAccountByAccountNumber(Input.GetString("Enter account number: "), brand);
                if (account != null) break;
            }
            while (true)
            {
                Write("\nYour balance : ");
                Printer.InformColor(account?.Balance.ToString() + "\n", "Cy");
                string type = Input.GetString("Enter type (D/W): ");
                if ("D".Equals(type) || "W".Equals(type))
                {
                    double amount = Input.GetDouble("Enter amount: ");
                    if (amount > 0)
                    {
                        _bankRepository.TopupOrWithdrawAccount(account, new Transaction(amount, type));
                        break;
                    }
                    else Printer.InformColor("Amount must be greater than 0.", "DR");
                }
                else Printer.InformColor("Type must be D or W.", "DR");
            }
        }
        catch (Exception ex) { Printer.InformColor(ex.Message, "DR"); }
    }
    public void ListAllinAllTransaction()
    {
        List<Branch> branches = _bankRepository.GetBranchList();
        foreach (Branch branch in branches)
        {
            Printer.InformColor("\n" + branches.IndexOf(branch) + "-branch " + branch.ToString(), "Gr");
            foreach (Client client in branch.Clients)
            {
                Printer.InformColor("\n\tClient / " + client.ToString(), "Cy");
                foreach (Account account in client.Accounts)
                {
                    Printer.InformColor("\t\t[Account] - " + account.ToString(), "Yl");
                    foreach (Transaction transaction in account.Transactions) Printer.InformColor("\t\t\t[Transaction] - " + transaction.ToString(), "Mg");
                }
            }
        }
    }
    public void ListAccountWithBiggestBalanceOfEachClient()
    {
        List<Branch> branches = _bankRepository.GetBranchList();
        foreach (Branch branch in branches)
        {
            Printer.InformColor("\n" + branches.IndexOf(branch) + "-branch " + branch.ToString(), "Gr");
            foreach (Client client in branch.Clients)
            {
                Printer.InformColor("\n\tClient / " + client.ToString(), "Cy");
                foreach (Account account in _bankRepository.FindAllAccountsOfEachClientWithBiggestBalance(client)) Printer.InformColor("\t\t[Account] - " + account.ToString(), "Yl");
            }
        }
    }
    public void ShowingOrderOfClientsSortByTotalOfBalanceAscending()
    {
        Branch brand;
        while (true)
        {
            brand = _bankRepository.GetBrand(Input.GetString("Enter branch name: "), "name");
            if (brand != null) break;
        }
        List<Client> clients = _bankRepository.GetClientListByBranch(brand).OrderBy(c => _bankRepository.GetTotalBalanceOfEachClient(c))
                                                                           .ToList();
        Printer.InformColor("\n" + brand.Name.ToUpperInvariant() + "-branch " + brand?.ToString(), "Gr");
        foreach (Client client in clients)
        {
            Write("\tClient  /  " + client.ToString() + "\n\t[Total balance] : ");
            Printer.InformColor(_bankRepository.GetTotalBalanceOfEachClient(client).ToString() + "\n", "Yl");
        }
    }
    public void ShowClientWithTheMostNumberOfTransactions()
    {
        Write("\n\tClient / ");
        Printer.InformColor(_bankRepository.FindClientWithHighestNumberOfTransactions().ToString(), "Gr");
    }
    private int GetClientListOfABranch(Branch branch)
    {
        List<Client> clients = _bankRepository.GetClientListOfABranch(branch);
        if (clients.Count == 0)
        {
            Printer.InformColor("\nThere is no client in database.", "DR");

            return 0;
        }
        else
        {
            WriteLine();
            foreach (Client client in clients) WriteLine(client.ToString());

            return 1;
        }
    }
}