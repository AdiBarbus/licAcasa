using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.IService
{
    public interface IAnswerService
    {
        IQueryable<Answer> GetAnswerByQuestion(int questionId);
        IQueryable<Answer> GetRightAnswers();
        IQueryable<Answer> GetAnswers();
        Answer GetAnswer(int id);
        void InsertAnswer(Answer answer);
        void DeleteAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
    }
}
