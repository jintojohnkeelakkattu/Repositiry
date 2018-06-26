
using System.Linq;

namespace JobMaster.Service
{
    public interface IAdminService
    {
        IQueryable<Job> GetAllJobs();

    }
}
