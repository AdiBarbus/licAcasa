using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class DomainService : IDomainService
    {
        private readonly IRepository<Domain> repository;
        private readonly IRepository<SubDomain> subDomainRepository;
        private readonly IRepository<Advertise> advertiseRepository;

        public DomainService(IRepository<Domain> repo, IRepository<SubDomain> subDomainRepo, IRepository<Advertise> advertiseRepo)
        {
            repository = repo;
            subDomainRepository = subDomainRepo;
            advertiseRepository = advertiseRepo;
        }
        
        public IQueryable<SubDomain> GetSubDomainsByDomain(int domainId)
        {
            try
            {
                return subDomainRepository.GetAll().Where(e => e.DomainId == domainId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<Advertise> GetAdvertisesByDomain(int domainId)
        {
            try
            {
                return advertiseRepository.GetAll().Where(e => e.DomainId == domainId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<Domain> GetDomains()
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

        public Domain GetDomain(int id)
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

        public void InsertDomain(Domain domain)
        {
            try
            {
                if (domain != null) repository.Insert(domain);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteDomain(Domain domain)
        {
            try
            {
                repository.Delete(domain);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateDomain(Domain domain)
        {
            try
            {
                repository.Update(domain);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}