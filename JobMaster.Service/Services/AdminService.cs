
using System.Linq;
using JobMaster.Service.ViewModels;
using System.Collections.Generic;
using System;

namespace JobMaster.Service
{
    public class AdminService : IAdminService
    {
        private readonly IRepository _repository;

        public AdminService(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(JobInformation jobInformation)
        {
            Job job = new Job()
            {
                Title = jobInformation.Title,
                Description = jobInformation.Description,
                Experience = jobInformation.Experience,
                Company = jobInformation.Company,
                SalaryFrom = Convert.ToInt32(jobInformation.SalaryFrom),
                SalaryTo = Convert.ToInt32(jobInformation.SalaryTo),
                UserId = 1
            };
            _repository.Add<Job>(job);
            _repository.Save();
        }

        public void Delete(long id)
        {
            if (id > 0)
            {
               // Job job = _repository.Get(id);
               // _repository.Delete<Job>(job);
                _repository.Save();
            }
        }

        public IQueryable<Job> GetAllJobs()
        {
            return _repository.GetAll<Job>().OrderByDescending(r => r.Id).OrderBy(r => r.Title);
        }

        public IQueryable<JobsApplied> GetAllJobsApplied()
        {
            //List <JobsApplied> jobsApplied= new List<JobsApplied>();
            //jobsApplied = from user in _repository.GetAll<UserDetail>()
            //             join job in _repository.GetAll<Job>() on user.Id equals job.UserId
            //             select new { };
            return _repository.GetAll<JobsApplied>().OrderByDescending(r => r.Id).OrderBy(r => r.Name);
        }

        public IQueryable<UserDetail> GetAllUsers()
        {
            return _repository.GetAll<UserDetail>().OrderByDescending(r => r.Id).OrderBy(r => r.FirstName);
        }

        public void Update(Job job)
        {
            throw new System.NotImplementedException();
        }
    }
}
