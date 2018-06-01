using JobMaster.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobMaster.Service
{
    public interface IUserDetailService
    {
        IEnumerable<UserDetail> GetUserDetails();
        Task<UserDetail> GetUserDetail(long id);
        Task InsertUserDetail(UserDetail userDetail);
        Task UpdateUserDetail(UserDetail userDetail);
        Task DeleteUserDetail(long id);
    }
}
