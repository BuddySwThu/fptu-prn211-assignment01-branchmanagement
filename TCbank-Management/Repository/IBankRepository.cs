using Techcombank.Entity;

namespace Techcombank.Repository;

public interface IBankRepository
{
    public List<Branch> GetBranchList();
    public void AddBranch(Branch branch);
    public void AddClientToBranch(string compare, List<Client> clients);
    public List<Client> GetClientListOfABranch(Branch branch);
    public void AddAccountToClient(string clieID, List<Account> account);
    public Client[] GetClientByName(string clieName);
    public void TopupOrWithdrawAccount(Account account, Transaction transaction);
    public Branch GetBrand(string compare, string which);
    public Account GetAccountByAccountNumber(string accountNumber, Branch branchW);
    public List<Account> FindAllAccountsOfEachClientWithBiggestBalance(Client client);
    public List<Client> GetClientListByBranch(Branch branch);
    public double GetTotalBalanceOfEachClient(Client client);
    public Client FindClientWithHighestNumberOfTransactions();
}