using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.Models.SelectFK
{
    public class SelectRoleViewModel
    {
        public IQueryable<Role> Roles { get; set; }
        public int SelectedRoleId { set; get; }
    }
}