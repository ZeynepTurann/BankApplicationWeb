using BankApp.MVC.Infrastructures.Entities;
using BankApp.MVC.Infrastructures.UnitOfWork;
using BankApp.MVC.Mapping;
using BankApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserMapper _userMapper;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUserMapper userMapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userMapper = userMapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _unitOfWork.GetRepository<ApplicationUser>().GetAll();
            return View(_userMapper.MapToListOfUserList(users));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
