

using JobMaster.Data;
using JobMaster.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public async Task CreateUser(RegisterUser registerUser)
        {
            var isExistingUser = _dbContext.Users.Any(r => r.UserName == registerUser.UserName);

            if (isExistingUser)
            {
                throw new ActionNotCompletedException($"{registerUser.UserName} already exist.");
            }

            HashedPassword hashedPassword = new HashedPassword(registerUser.Password, 2);

            User user = new User()
            {
                UserName = registerUser.UserName,
                HashedPassword = hashedPassword.Hash,
                Salt = hashedPassword.Salt,
                Email = registerUser.Email
            };

            _dbContext.Users.Add(user);
           await  _dbContext.SaveChangesAsync();
        }

        public void UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ValidateUser(LoginUser loginUser)
        {
            var isUserExist = _dbContext.Users.Any(r => r.UserName == loginUser.UserName);
            if (!isUserExist)
            {
                throw new ActionNotCompletedException($"{loginUser.UserName} doesn't exist.");
            }
            var user = await _dbContext.Users.SingleAsync(u => u.UserName == loginUser.UserName);
            HashedPassword hp = new HashedPassword(user.Salt, user.HashedPassword, 2);

            if (!hp.CheckPassword(loginUser.Password))
            {
                throw new ActionNotCompletedException("Invalid credentials");
            }

            return true;
        }

        public List<string> GetUserRoles(string userName)
        {
            var user = _dbContext.Users.Single(r => r.UserName == userName);
            var userRoles = _dbContext.UserRoles
                .Join(_dbContext.Roles, u => u.RoleId, r => r.Id, (u, r) =>
                   new
                   {
                       r.Name,
                       u.UserId
                   }).Where(r => r.UserId == user.Id).Select(t => t.Name)

                   ;
            if (userRoles != null && userRoles.Count() > 0)
                return (List<string>)userRoles;
            else return null;
        }

        public IEnumerable<Job> GetTopJobs()
        {
            var jobs = _dbContext.Jobs.ToList();
            return jobs;
        }
    }
}
