using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> repository;

        public RoleService(IRepository<Role> repo)
        {
            repository = repo;
        }
        public IQueryable<Role> GetRoles()
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

        public Role GetRole(int id)
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
    }
}
