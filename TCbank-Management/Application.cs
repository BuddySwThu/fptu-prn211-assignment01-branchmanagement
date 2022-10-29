using Techcombank.BussinessObject;
using Techcombank.DataAccess;
using Techcombank.Entity;
using Techcombank.Utils;

namespace Techcombank.Application;
public class Application
{
    public static void Main(string[] args)
    {
        InitializeDefaultBranchOfBank();
        Menu menu = new("Welcome to Techcombank management system",
                        new List<string> { "Create a new branch.",
                                           "Print out information of clients.",
                                           "Deposit or Withdraw.",
                                           "List all transactions.",
                                           "List account with biggest balance of each client.",
                                           "Show list of client and sort by total of balance.",
                                           "Show client with the most number of transactions.",
                                           "Exit." });
        while (true)
        {
            menu.Display();
            int choice = menu.GetChoice();
            switch (choice)
            {
                case 1: menu.CreateNewBranch(); break;
                case 2: menu.PrintouClientInfo(); break;
                case 3: menu.DepositOrWithdraw(); break;
                case 4: menu.ListAllinAllTransaction(); break;
                case 5: menu.ListAccountWithBiggestBalanceOfEachClient(); break;
                case 6: menu.ShowingOrderOfClientsSortByTotalOfBalanceAscending(); break;
                case 7: menu.ShowClientWithTheMostNumberOfTransactions(); break;
            }
            if (choice == menu.Options.Count) break;
        }
    }
    private static void InitializeDefaultBranchOfBank()
    {
        //-----------------------------------------------Transactions-------------------------------------------------
        List<Transaction> _Transactions1 = new()
        {
            new Transaction(amount: 1000, type: "D"),
            new Transaction(amount: 2000, type: "T"),
            new Transaction(amount: 3000, type: "T"),
            new Transaction(amount: 4000, type: "D"),
            new Transaction(amount: 5000, type: "D")
        }; List<Transaction> _Transactions2 = new()
        {
            new Transaction(amount: 6000, type: "D"),
            new Transaction(amount: 7000, type: "T"),
            new Transaction(amount: 8000, type: "T"),
            new Transaction(amount: 9000, type: "D"),
            new Transaction(amount: 10000, type: "D")
        }; List<Transaction> _Transactions3 = new()
        {
            new Transaction(amount: 1100, type: "D"),
            new Transaction(amount: 2200, type: "T"),
            new Transaction(amount: 3300, type: "T"),
            new Transaction(amount: 4400, type: "D"),
            new Transaction(amount: 5500, type: "D")
        }; List<Transaction> _Transactions4 = new()
        {
            new Transaction(amount: 6600, type: "D"),
            new Transaction(amount: 7700, type: "T"),
            new Transaction(amount: 8800, type: "T"),
            new Transaction(amount: 9900, type: "D"),
            new Transaction(amount: 1120, type: "D")
        }; List<Transaction> _Transactions5 = new()
        {
            new Transaction(amount: 2230, type: "D"),
            new Transaction(amount: 3340, type: "T"),
            new Transaction(amount: 4450, type: "T"),
            new Transaction(amount: 5560, type: "D"),
            new Transaction(amount: 6670, type: "D")
        }; List<Transaction> _Transactions6 = new()
        {
            new Transaction(amount: 2230, type: "D"),
            new Transaction(amount: 3340, type: "T"),
            new Transaction(amount: 4450, type: "T"),
            new Transaction(amount: 5560, type: "D"),
            new Transaction(amount: 6670, type: "D")
        }; List<Transaction> _Transactions7 = new()
        {
            new Transaction(amount: 7780, type: "D"),
            new Transaction(amount: 8890, type: "T"),
            new Transaction(amount: 9910, type: "T"),
            new Transaction(amount: 1111, type: "D"),
            new Transaction(amount: 2222, type: "D")
        };


        //-----------------------------------------------Accounts-------------------------------------------------
        List<Account> _Accounts1 = new()
        {
            new Account(balance: 1100000, transactions: _Transactions1),
            new Account(balance: 2200000, transactions: _Transactions3),
            new Account(balance: 3300000, transactions: _Transactions5),
            new Account(balance: 4400000, transactions: _Transactions7)
        }; List<Account> _Accounts2 = new()
        {
            new Account(balance: 5500000, transactions: _Transactions2),
            new Account(balance: 6600000, transactions: _Transactions4),
            new Account(balance: 7700000, transactions: _Transactions6),
            new Account(balance: 8800000, transactions: _Transactions2)
        }; List<Account> _Accounts3 = new()
        {
            new Account(balance: 9900000, transactions: _Transactions3),
            new Account(balance: 1120000, transactions: _Transactions2),
            new Account(balance: 2230000, transactions: _Transactions5),
            new Account(balance: 3340000, transactions: _Transactions6)
        }; List<Account> _Accounts4 = new()
        {
            new Account(balance: 4450000, transactions: _Transactions7),
            new Account(balance: 5560000, transactions: _Transactions7),
            new Account(balance: 6670000, transactions: _Transactions6),
            new Account(balance: 7780000, transactions: _Transactions1)
        }; List<Account> _Accounts5 = new()
        {
            new Account(balance: 8890000, transactions: _Transactions2),
            new Account(balance: 9910000, transactions: _Transactions3),
            new Account(balance: 11220000, transactions: _Transactions7),
            new Account(balance: 2233000, transactions: _Transactions3)
        }; List<Account> _Accounts6 = new()
        {
            new Account(balance: 3344000, transactions: _Transactions4),
            new Account(balance: 4455000, transactions: _Transactions5),
            new Account(balance: 5566000, transactions: _Transactions1),
            new Account(balance: 6677000, transactions: _Transactions6)
        };


        //-----------------------------------------------Clients-------------------------------------------------
        List<Client> _Clients = new()
        {
            new Client(name: "Nguyen Minh Phi", address: new Address(street: "95/22 XVNT", ward: "Q.Binh Thanh", city: "Sai Gon"), accounts: _Accounts1),
            new Client(name: "To Huu Bang", address: new Address(street: "95/22 XVNT", ward: "Q.Binh Thanh", city: "Sai Gon"), accounts: _Accounts2),
            new Client(name: "Dinh Le Thu", address: new Address(street: "95/22 XVNT", ward: "Q.Binh Thanh", city: "Sai Gon"), accounts: _Accounts3),
            new Client(name: "Tran Manh Cuong", address: new Address(street: "95/22 XVNT", ward: "Q.Binh Thanh", city: "Sai Gon"), accounts: _Accounts4),
            new Client(name: "Ngo Chau Minh", address: new Address(street: "95/22 XVNT", ward: "Q.Binh Thanh", city: "Sai Gon"), accounts: _Accounts5),
            new Client(name: "Nguyen The Bao", address: new Address(street: "95/22 XVNT", ward: "Q.Binh Thanh", city: "Sai Gon"), accounts: _Accounts6)
        };


        //Branch
        TCBDBContext.GetBranchList.Add(new Branch(name: "Diamond Banker",
                                                  address: new Address(street: "95/22 XVNT", ward: "Q.Binh Thanh", city: "Sai Gon"),
                                                  clients: _Clients));
        //TCBDBContext.GetBranchList.Add(new Branch(name: "Golden Banker",
        //                                          address: new Address(street: "109A Lam Son", ward: "Q.Tan Binh", city: "Sai Gon"),
        //                                          clients: _Clients));
    }
}