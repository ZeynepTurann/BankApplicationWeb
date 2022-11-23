using BankApp.MVC.Infrastructures.Entities;
using BankApp.MVC.Models;

namespace BankApp.MVC.Mapping
{
    public class AccountMapper:IAccountMapper
    {
        public Account Map(AccountCreateModel model)
        {
            return new Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            };
        }

        public AccountListModel ReverseMap(Account account)
        {
            return new AccountListModel
            {
                AccountNumber = account.AccountNumber,
                ApplicationUserId = account.ApplicationUserId,
                Balance = account.Balance,
                Id = account.Id
            };
        }
    }
}
