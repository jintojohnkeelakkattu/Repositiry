
using JobMaster.Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMaster.Service
{
   public interface IUserService
    {
        IEnumerable<T> GetUsers();
        T GetUser(long id);
        void CreateUser(RegisterUser user);
        Task<bool> ValidateUser(LoginUser user);
        void UpdateUser(T user);
        void DeleteUser(long id);
        IQueryable<Job> GetTopJobs();
        IList<string> GetUserRoles(string userName);
    }
}
