using System;
using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class AnswerService : IAnswerService
    {
        private readonly IRepository<Answer> repository;

        public AnswerService(IRepository<Answer> repo)
        {
            repository = repo;
        }

        public IQueryable<Answer> GetAnswerByQuestion(int questionId)
        {
            try
            {
                return repository.GetAll().Where(e => e.QuestionId == questionId && e.IsCorrect == true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<Answer> GetRightAnswers()
        {
            try
            {
                return repository.GetAll().Where(e => e.IsCorrect == true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IQueryable<Answer> GetAnswers()
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

        public Answer GetAnswer(int id)
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

        public void InsertAnswer(Answer answer)
        {
            try
            {
                if (answer != null) repository.Insert(answer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteAnswer(Answer answer)
        {
            try
            {
                repository.Delete(answer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateAnswer(Answer answer)
        {
            try
            {
                repository.Update(answer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}