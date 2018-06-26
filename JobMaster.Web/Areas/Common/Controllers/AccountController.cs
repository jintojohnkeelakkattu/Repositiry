
using JobMaster.Service;
using JobMaster.Service.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobMaster.Web.Areas.Admin.Controllers
{
    [Area("Common")]
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind] LoginUser loginUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var success = await userService.ValidateUser(loginUser);
                    if (success)
                    {
                        var roles = userService.GetUserRoles(loginUser.UserName);
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, loginUser.UserName));
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "Credentials");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.SignInAsync(principal);
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                        return View();
                    }
                    //    ModelState.Clear();
                    //    ViewBag.Message = "Created Successfully.";
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