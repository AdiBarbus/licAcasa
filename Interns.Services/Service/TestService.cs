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
        private readonly IRepository<Question> questionRepository;

        public TestService(IRepository<Test> repo, IRepository<Question> questionRepo)
        {
            repository = repo;
            questionRepository = questionRepo;
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

        public IQueryable<Question> GetQuestionsByTests(int testId)
        {
            try
            {
                return questionRepository.GetAll().Where(e => e.TestId == testId);
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