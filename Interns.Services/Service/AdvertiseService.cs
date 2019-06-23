using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class AdvertiseService : IAdvertiseService
    {
        private readonly IRepository<Advertise> repository;

        public AdvertiseService(IRepository<Advertise> repo)
        {
            repository = repo;
        }

        public IQueryable<Advertise> GetAdvertises()
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

        public Advertise GetAdvertise(int id)
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

        public void InsertAdvertise(Advertise advertise)
        {
            try
            {
                repository.Insert(advertise);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteAdvertise(Advertise advertise)
        {
            try
            {
                repository.Delete(advertise);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateAdvertise(Advertise advertise)
        {
            try
            {
                repository.Update(advertise);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
