using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class TestService : ITestService
    {
        private readonly IRepository<Test> repository;

        public TestService(IRepository<Test> repo)
        {
            repository = repo;
        }

      
        public IQueryable<Test> GetTests()
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

        public Test GetTest(int id)
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

        public void InsertTest(Test test)
        {
            try
            {
                if (test != null) repository.Insert(test);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteTest(Test test)
        {
            try
            {
                repository.Delete(test);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateTest(Test test)
        {
            try
            {
                repository.Update(test);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}