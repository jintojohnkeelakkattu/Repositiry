
using JobMaster.Service.ViewModels;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobMaster.Service
{
   public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        Task CreateUser(RegisterUser user);
        Task<bool> ValidateUser(LoginUser user);
        void UpdateUser(User user);
        void DeleteUser(long id);
        IEnumerable<Job> GetTopJobs();
    }
}
