using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class SubDomainService : ISubDomainService
    {
        private readonly IRepository<SubDomain> repository;
        private readonly IRepository<Advertise> advertiseRepository;

        public SubDomainService(IRepository<SubDomain> repo, IRepository<Advertise> advertiseRepo)
        {
            repository = repo;
            advertiseRepository = advertiseRepo;
        }

        public IQueryable<SubDomain> GetSubDomains()
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

        public SubDomain GetSubDomain(int id)
        {
            try
            {
                return repository.GetById(id); //a => a.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IQueryable<Advertise> GetAdvertisesBySubDomain(int domainId)
        {
            try
            {
                return advertiseRepository.GetAll().Where(e => e.DomainId == domainId).Where(e => e.SubDomainId == domainId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InsertSubDomain(SubDomain subDomain)
        {
            try
            {
                if (subDomain != null)
                {
                    repository.Insert(subDomain);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteSubDomain(SubDomain subDomain)
        {
            try
            {
                repository.Delete(subDomain);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateSubDomain(SubDomain subDomain)
        {
            try
            {
                repository.Update(subDomain);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
