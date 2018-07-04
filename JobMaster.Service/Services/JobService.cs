
using System.Linq;
using JobMaster.Service.ViewModels;
using System.Collections.Generic;
using System;

namespace JobMaster.Service
{
    public class JobService : IJobService
    {
        private readonly IRepository _repository;

        public JobService(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(JobInformation jobInformation, string username)
        {

            Job job = new Job()
            {
                Title = jobInformation.Title,
                Description = jobInformation.Description,
                Experience = jobInformation.Experience,
                Company = jobInformation.Company,
                SalaryFrom = Convert.ToInt32(jobInformation.SalaryFrom),
                SalaryTo = Convert.ToInt32(jobInformation.SalaryTo),
                UserId = _repository.GetAll<User>().Single(r => r.UserName == username).Id
            };
            _repository.Add<Job>(job);
            _repository.Save();
        }

        public void Delete(long id)
        {
            if (id > 0)
            {

                var job = _repository.GetAll<Job>().SingleOrDefault(r => r.Id == id);
                if (job == null)
                {
                    throw new ActionNotCompletedException("Job could not be found");
                }
                _repository.Delete<Job>(job);
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

        public void Update(JobInformation jobInformation)
        {
            if (jobInformation == null)
            {
                throw new ActionNotCompletedException("Invalid details");
            }

            Job job = _repository.GetAll<Job>().Single(match => match.Id == jobInformation.Id);
            job.Title = jobInformation.Title;
            job.Description = jobInformation.Description;
            job.Experience = jobInformation.Experience;
            job.Company = jobInformation.Company;
            job.SalaryFrom = Convert.ToInt32(jobInformation.SalaryFrom);
            job.SalaryTo = Convert.ToInt32(jobInformation.SalaryTo);

            //_repository.Update<Job>(job);
            _repository.Save();
        }
    }
}
