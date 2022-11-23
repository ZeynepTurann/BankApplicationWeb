using BankApp.MVC.Infrastructures.Entities;
using BankApp.MVC.Models;
using System.Collections.Generic;

namespace BankApp.MVC.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> users);
        UserListModel MapToUserList(ApplicationUser user);
    }
}
