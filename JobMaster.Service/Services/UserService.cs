

using JobMaster.Data;
using JobMaster.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using JobMaster.Entities;

namespace JobMaster.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }
        public void DeleteUser(long id)
        {
            throw new System.NotImplementedException();
        }

        public T GetUser(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetUsers()
        {
            return _repository.GetAll<T>();
        }

        public void CreateUser(RegisterUser registerUser)
        {
            var isExistingUser = _repository.GetAll<T>().Any(r => r.UserName == registerUser.UserName);

            if (isExistingUser)
            {
                throw new ActionNotCompletedException($"{registerUser.UserName} already exist.");
            }

            HashedPassword hashedPassword = new HashedPassword(registerUser.Password, 2);

            T user = new T()
            {
                UserName = registerUser.UserName,
                HashedPassword = hashedPassword.Hash,
                Salt = hashedPassword.Salt,
                Email = registerUser.Email
            };

            // add user
            user.UserRoles.Add(new UserRole()
            {
                User = user,
                Role = _repository.GetAll<Role>().Where(r => r.Id == (int)Roles.Admin).First()
            });
            _repository.Add<T>(user);
            _repository.Save();
        }

        public void UpdateUser(T user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> ValidateUser(LoginUser loginUser)
        {
            var isUserExist = _repository.GetAll<T>().Any(r => r.UserName == loginUser.UserName);
            if (!isUserExist)
            {
                throw new ActionNotCompletedException($"{loginUser.UserName} doesn't exist.");
            }
            var user = await _repository.GetAll<T>().SingleAsync(u => u.UserName == loginUser.UserName);
            HashedPassword hp = new HashedPassword(user.Salt, user.HashedPassword, 2);

            if (!hp.CheckPassword(loginUser.Password))
            {
                throw new ActionNotCompletedException("Invalid credentials");
            }

            return true;
        }

        //public List<string> GetUserRoles(string userName)
        //{
        //    var user = _dbContext.Users.Single(r => r.UserName == userName);
        //    var userRoles = _dbContext.UserRoles
        //        .Join(_dbContext.Roles, u => u.RoleId, r => r.Id, (u, r) =>
        //           new
        //           {
        //               r.Name,
        //               u.UserId
        //           }).Where(r => r.UserId == user.Id).Select(t => t.Name)

        //           ;
        //    if (userRoles != null && userRoles.Count() > 0)
        //        return (List<string>)userRoles;
        //    else return null;
        //}

        //public IEnumerable<Job> GetTopJobs()
        //{
        //    var jobs = _dbContext.Jobs.ToList();
        //    return jobs;
        //}



        IQueryable<Job> IUserService.GetTopJobs()
        {
            return _repository.GetAll<Job>();
        }

        public IList<string> GetUserRoles(string userName)
        {
            var user = _repository.GetAll<T>().Where(t => t.UserName == userName).SingleOrDefault();
            if (user == null)
            {
                throw new ActionNotCompletedException("User roles not defined");
            }

            return _repository.GetAll<UserRole>().Include(r=>r.Role).Where(r => r.UserId == user.Id).Select(r => r.Role.Name).ToList();
        }
    }
}
