using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface IRoleService
    {
        IQueryable<Role> GetRoles();
        Role GetRole(int id);
    }
}
