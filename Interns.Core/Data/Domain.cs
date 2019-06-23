using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interns.Core.Data
{
    public class Domain : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<SubDomain> SubDomains { get; set; }

        public virtual ICollection<Advertise> Advertises { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
