using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class QAService : IQaService
    {
        private readonly IRepository<Qa> repository;

        public QAService(IRepository<Qa> repo)
        {
            repository = repo;
        }

        public IQueryable<Qa> GetQas()
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

        public Qa GetQa(int id)
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

        public void InsertQa(Qa qa)
        {
            try
            {
                if (qa != null)
                {
                    repository.Insert(qa);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteQa(Qa qa)
        {
            try
            {
                repository.Delete(qa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateQa(Qa qa)
        {
            try
            {
                repository.Update(qa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
