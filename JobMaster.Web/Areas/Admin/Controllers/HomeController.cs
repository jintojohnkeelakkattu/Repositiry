using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobMaster.Service;
using System.Dynamic;

namespace JobMaster.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IAdminService adminService;
        public HomeController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        [HttpPost]
        public JsonResult GetAllJobs()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            // Skip number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();

            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();

            // Sort Column Name  
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            // Sort Column Direction (asc, desc)  
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            // Search Value from (Search box)  
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10, 20, 50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            //int recordsTotal = 0;

            var jobs =  adminService.GetAllJobs().Select(r => new
            {
                r.Id,
                r.Title,
                r.Company,
                r.Description,
                Salary = $"{r.SalaryFrom / 1000}k-{r.SalaryTo / 1000}k"
            });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
               // jobs = jobs.OrderBy(r=>r.Title == sortColumn + " " + sortColumnDirection);
            }
            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                jobs = jobs.Where(m => m.Title.ToLower().Contains(searchValue.ToLower()));
            }
            var data = jobs.Skip(skip).Take(pageSize).ToList();
            dynamic jobDetails = new ExpandoObject();
            jobDetails.data = data;
            return Json(new { draw = "", recordsFiltered = jobs.Count(), recordsTotal = jobs.Count(), data = data });
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}