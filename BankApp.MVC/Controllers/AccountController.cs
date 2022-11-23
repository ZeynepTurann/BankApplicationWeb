using BankApp.MVC.Infrastructures.Entities;
using BankApp.MVC.Infrastructures.UnitOfWork;
using BankApp.MVC.Mapping;
using BankApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserMapper _userMapper;
        private readonly IAccountMapper _accountMapper;

        public AccountController(IUnitOfWork unitOfWork, IUserMapper userMapper, IAccountMapper accountMapper)
        {
            _unitOfWork = unitOfWork;
            _userMapper = userMapper;
            _accountMapper = accountMapper;
        }

        public async Task<IActionResult> Create(int id)
        {
            var userInfo = await _unitOfWork.GetRepository<ApplicationUser>().GetById(id);
            return View(_userMapper.MapToUserList(userInfo));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountCreateModel model)
        {
            var account=_accountMapper.Map(model);
            await _unitOfWork.GetRepository<Account>().Create(account);
            await _unitOfWork.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            //var query = _accountgenericRepository.GetQueryable();
            var query =  _unitOfWork.GetRepository<Account>().GetQueryable();
            var accountList = query.Where(x => x.ApplicationUserId == userId).ToList();
            var user = await _unitOfWork.GetRepository<ApplicationUser>().GetById(userId);
            ViewBag.FullName = user.Name + " " + user.Surname;
            var list = new List<AccountListModel>();     //
            foreach (var account in accountList)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId = account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }

            return View(list);

        }

        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _unitOfWork.GetRepository<Account>().GetQueryable();
            var accounts = query.Where(x => x.Id != accountId).ToList();

            var list = new List<AccountListModel>();
            ViewBag.SenderId = accountId;  //SenderId => Id of account whose the money will be sent
            foreach (var account in accounts)
            {
                list.Add(_accountMapper.ReverseMap(account));
            }
            return View(new SelectList(list, "Id", "AccountNumber"));
        }

        [HttpPost]
        public async Task<IActionResult> SendMoney(SendMoneyModel model)
        { 
            var senderAccount = await _unitOfWork.GetRepository<Account>().GetById(model.SenderId);
            var receiverAccount = await _unitOfWork.GetRepository<Account>().GetById(model.AccountId);

            /*We update the balances of the recipient and sender 
            accounts that we obtained with the GetById method inside the generic repository*/
            senderAccount.Balance -= model.Amount;

            _unitOfWork.GetRepository<Account>().Update(senderAccount);
             receiverAccount.Balance += model.Amount;
            _unitOfWork.GetRepository<Account>().Update(receiverAccount);

            await _unitOfWork.SaveChanges();
            /*We made the changes in both accounts after the desired transactions
             were completed. Therefore,SaveChanges() method is inside the UnitOfWork Class
             We manage from a separate unit. Also,it  aggregate all Repository transactions (CRUD) 
            into a single transaction. Only one commit will be made for all modifications.  */

            return RedirectToAction("Index", "Home");
        }


    }
}
