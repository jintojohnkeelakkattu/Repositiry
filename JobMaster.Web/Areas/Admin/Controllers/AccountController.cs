
using JobMaster.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobMaster.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([Bind] RegisterUser register)
        {
            if (ModelState.IsValid)
            {

            }
                return View();
        }

    }
}