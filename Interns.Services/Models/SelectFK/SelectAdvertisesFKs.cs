using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.Models.SelectFK
{
    public class SelectAdvertisesFKs
    {
        public IQueryable<Domain> Domains { get; set; }
        public int SelectedDomainId { set; get; }
        public IQueryable<SubDomain> SubDomains { get; set; }
        public int SelectedSubDomainId { set; get; }
        public IQueryable<User> Users { get; set; }
        public int SelectedUserId { set; get; }
        public Advertise Advertise { get; set; }
    }
}
