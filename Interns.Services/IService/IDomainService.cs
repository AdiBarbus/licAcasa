using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface IDomainService
    {
        IQueryable<Domain> GetDomains();
        IQueryable<SubDomain> GetSubDomainsByDomain(int id);
        IQueryable<Advertise> GetAdvertisesByDomain(int id);
        Domain GetDomain(int id);
        void InsertDomain(Domain domain);
        void DeleteDomain(Domain domain);
        void UpdateDomain(Domain domain);
    }
}