using System.Collections.Generic;
using Interns.Core.Data;
using System.Linq;

namespace Interns.Services.Models
{
    public class QAModelView
    {
        public IQueryable<Question> Questions { get; set; }
        public IQueryable<Answer> Answers { get; set; }
    }
}
