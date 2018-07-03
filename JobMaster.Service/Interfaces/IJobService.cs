
using JobMaster.Service.ViewModels;
using System.Linq;

namespace JobMaster.Service
{
    public interface IJobService
    {
        IQueryable<Job> GetAllJobs();

        IQueryable<UserDetail> GetAllUsers();

        IQueryable<JobsApplied> GetAllJobsApplied();

        void Add(JobInformation jobInformation, string username);
        void Update(Job job);   
        void Delete(long id);

    }
}
