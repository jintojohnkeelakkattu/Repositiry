﻿
using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Web.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}