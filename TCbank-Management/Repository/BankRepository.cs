using Techcombank.DataAccess;
using Techcombank.Entity;

namespace Techcombank.Repository;

public class BankRepository : IBankRepository
{
    public List<Branch> GetBranchList() => TCBDBContext.GetBranchList;
    public void AddBranch(Branch branch) => TCBDBContext.Instance.AddBranch(branch);
    public void AddClientToBranch(string compare, List<Client> clients) => TCBDBContext.Instance.AddClientsToBranch(compare, clients);
    public List<Client> GetClientListOfABranch(Branch branch) => TCBDBContext.Instance.GetClientListOfABranch(branch);
    public void AddAccountToClient(string clieID, List<Account> accounts) => TCBDBContext.Instance.AddAccountToClient(clieID, accounts);
    public Client[] GetClientByName(string clieName) => TCBDBContext.Instance.GetClientByName(clieName);
    public void TopupOrWithdrawAccount(Account account, Transaction transaction) => TCBDBContext.Instance.TopupOrWithdrawAccount(account, transaction);
    public Branch GetBrand(string compare, string which) => TCBDBContext.Instance.GetBranch(compare, which);
    public Account GetAccountByAccountNumber(string accountNumber, Branch branchW) => TCBDBContext.Instance.GetAccountByAccountNumber(accountNumber, branchW);
    public List<Account> FindAllAccountsOfEachClientWithBiggestBalance(Client client) => TCBDBContext.Instance.FindAllAccountsOfEachCustomerWithBiggestBalance(client);
    public List<Client> GetClientListByBranch(Branch branch) => TCBDBContext.Instance.GetClientListByBranch(branch);
    public double GetTotalBalanceOfEachClient(Client client) => TCBDBContext.Instance.GetTotalBalanceOfEachClient(client);
    public Client FindClientWithHighestNumberOfTransactions() => TCBDBContext.Instance.FindClientWithHighestNumberOfTransactions();
}