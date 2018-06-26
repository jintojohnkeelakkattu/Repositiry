
using System.Linq;

namespace JobMaster.Service
{
    public class AdminService : IAdminService
    {
        private readonly IRepository _repository;
     
        public AdminService(IRepository repository)
        {
            _repository = repository;
        }
        public IQueryable<Job> GetAllJobs()
        {
           return _repository.GetAll<Job>().OrderByDescending(r=>r.Id).OrderBy(r=>r.Title);
        }
    }
}
