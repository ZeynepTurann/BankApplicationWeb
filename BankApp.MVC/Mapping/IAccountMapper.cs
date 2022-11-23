
using BankApp.MVC.Infrastructures.Entities;
using BankApp.MVC.Models;

namespace BankApp.MVC.Mapping
{
    public interface IAccountMapper
    {
        //without AutoMapper library
        Account Map(AccountCreateModel model);
        AccountListModel ReverseMap(Account account);
    }
}
