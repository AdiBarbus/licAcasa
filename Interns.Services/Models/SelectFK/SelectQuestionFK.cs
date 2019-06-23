using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.Models.SelectFK
{
    public class SelectQuestionFK
    {
        public IQueryable<Question> Questions { get; set; }
        public int SelectedQuestionId { set; get; }
    }
}
