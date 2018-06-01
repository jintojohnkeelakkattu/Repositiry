

using JobMaster.Data;
using System.Collections.Generic;

namespace JobMaster.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteUser(long id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users;
        }

        public void InsertUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
