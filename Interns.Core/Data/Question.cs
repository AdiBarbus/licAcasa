using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interns.Core.Data
{
    public class Question : BaseEntity
    {
        [Display(Name = "Question")]
        public string Quest { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Test Test { get; set; }

        public int? TestId { get; set; }

        public SubDomain SubDomain { get; set; }

        public int? SubDomainId { get; set; }

        public Domain Domain { get; set; }

        public int? DomainId { get; set; }
    }
}
