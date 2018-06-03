

using JobMaster.Data;
using JobMaster.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
    }
}
