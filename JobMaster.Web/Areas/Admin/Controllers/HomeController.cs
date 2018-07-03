using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobMaster.Service;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using JobMaster.Service.ViewModels;
using System.Security.Claims;

namespace JobMaster.Web.Areas.Admin.Controllers
{
    [Authorize (Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : BaseController
    {
        private readonly IJobService jobService;
        public HomeController(IJobService _jobService)
        {
            jobService = _jobService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAllUsers()
        {
            return View("UsersList");
        }

        public IActionResult ListAllJobsApplied()
        {
            return View("JobsApplied");
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

            var jobs = jobService.GetAllJobs().Select(r => new
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

        [HttpPost]
        public JsonResult GetAllUsers()
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

            var users = jobService.GetAllUsers().Select(r => new
            {
                r.Id,
                r.FirstName,
                r.LastName,
                r.Address                
            });

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                // jobs = jobs.OrderBy(r=>r.Title == sortColumn + " " + sortColumnDirection);
            }
            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                users = users.Where(m => m.FirstName.ToLower().Contains(searchValue.ToLower()));
            }
            var data = users.Skip(skip).Take(pageSize).ToList();
            dynamic userDetails = new ExpandoObject();
            userDetails.data = data;
            return Json(new { draw = "", recordsFiltered = users.Count(), recordsTotal = users.Count(), data = data });
        }

        [HttpPost]
        public JsonResult GetAllJobsApplied()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            var users = jobService.GetAllJobsApplied().Select(r => new
            {
                r.Id,
                r.Name,
                r.Job,
                r.AppliedDate
            });
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                // jobs = jobs.OrderBy(r=>r.Title == sortColumn + " " + sortColumnDirection);
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                users = users.Where(m => m.Name.ToLower().Contains(searchValue.ToLower()));
            }
            var data = users.Skip(skip).Take(pageSize).ToList();
            dynamic userDetails = new ExpandoObject();
            userDetails.data = data;
            return Json(new { draw = "", recordsFiltered = users.Count(), recordsTotal = users.Count(), data = data });
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return PartialView("_AddJob");
        }

        [HttpPost]
        public ActionResult AddJob(JobInformation job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;

                    if (identity == null)
                    {
                        RedirectToAction("Common", "Login");
                    }
                    
                    jobService.Add(job, identity.Name);
                    ModelState.Clear();
                    ViewBag.Message = "Job added successfully.";
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
                ViewBag.ErrorMessage = GetErrorMessage();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            try
            {
                if(id>0)
                {
                    jobService.Delete(id);
                    ModelState.Clear();
                    ViewBag.Message = "Job deleted successfully.";
                }
            }
            catch(Exception ex)
            {
                HandleException(ex);
                ViewBag.ErrorMessage = GetErrorMessage();
            }            
            return RedirectToAction("Index");
        }
    }
}