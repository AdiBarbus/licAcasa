using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface IUserService
    {
        IQueryable<User> GetUsers();
        User GetUser(int id);
        void InsertUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}