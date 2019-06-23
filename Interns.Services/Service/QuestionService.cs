using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> repository;

        public QuestionService(IRepository<Question> repo)
        {
            repository = repo;
        }


        public IQueryable<Question> GetQuestions()
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

        public Question GetQuestion(int id)
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

        public void InsertQuestion(Question question)
        {
            try
            {
                if (question != null) repository.Insert(question);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteQuestion(Question question)
        {
            try
            {
                repository.Delete(question);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateQuestion(Question question)
        {
            try
            {
                repository.Update(question);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}