
using JobMaster.Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobMaster.Service
{
   public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        void CreateUser(RegisterUser user);
        Task<bool> ValidateUser(LoginUser user);
        void UpdateUser(User user);
        void DeleteUser(long id);
        IQueryable<Job> GetTopJobs();
        IList<string> GetUserRoles(string userName);
    }
}
