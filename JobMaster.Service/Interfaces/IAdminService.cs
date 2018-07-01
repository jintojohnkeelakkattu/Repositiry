
using JobMaster.Service.ViewModels;
using System.Linq;

namespace JobMaster.Service
{
    public interface IAdminService
    {
        IQueryable<Job> GetAllJobs();

        IQueryable<UserDetail> GetAllUsers();

        IQueryable<JobsApplied> GetAllJobsApplied();

        void Add(JobInformation jobInformation);
        void Update(Job job);   
        void Delete(long id);

    }
}
