using JobMaster.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobMaster.Service
{
    public class UserDetailService : IUserDetailService
    {
        public Task DeleteUserDetail(long id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetail> GetUserDetail(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDetail> GetUserDetails()
        {
            throw new NotImplementedException();
        }

        public Task InsertUserDetail(UserDetail userDetail)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserDetail(UserDetail userDetail)
        {
            throw new NotImplementedException();
        }
    }
}
