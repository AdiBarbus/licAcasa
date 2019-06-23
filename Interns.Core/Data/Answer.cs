using System.ComponentModel.DataAnnotations;

namespace Interns.Core.Data
{
    public class Answer : BaseEntity
    {
        [Display(Name ="Answer")]
        public string Ans { get; set; }

        [Display(Name = "Correct Answer")]
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}
