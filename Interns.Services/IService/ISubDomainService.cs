using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface ISubDomainService
    {
        IQueryable<SubDomain> GetSubDomains();
        SubDomain GetSubDomain(int id);
        IQueryable<Advertise> GetAdvertisesBySubDomain(int domainId);
        void InsertSubDomain(SubDomain subDomain);
        void DeleteSubDomain(SubDomain subDomain);
        void UpdateSubDomain(SubDomain subDomain);
    }
}