using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;

        public UserService(IRepository<User> repo)
        {
            repository = repo;
        }

        public IQueryable<User> GetUsers()
        {
            try
            {
                return repository.GetAll();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User GetUser(int id)
        {
            try
            {
                return repository.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertUser(User user)
        {
            try
            {
                if (user != null)
                {
                    repository.Insert(user);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteUser(User user)
        {
            try
            {
                repository.Delete(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                repository.Update(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
