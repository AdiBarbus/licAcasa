using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface IQuestionService
    {
        IQueryable<Question> GetQuestions();
        Question GetQuestion(int id);
        void InsertQuestion(Question question);
        void DeleteQuestion(Question question);
        void UpdateQuestion(Question question);
    }
}
