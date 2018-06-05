
using JobMaster.Service;
using JobMaster.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JobMaster.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : BaseController
    {
        private readonly IUserService userService;
        public AccountController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind] RegisterUser register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  userService.CreateUser(register);
                  ModelState.Clear();
                  ViewBag.Message = "Created Successfully.";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
                ViewBag.ErrorMessage = GetErrorMessage();
            }
            return View();
        }

    }
}