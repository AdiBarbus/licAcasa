using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interns.Core.Data
{
    public class SubDomain : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Advertise> Advertises { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public int? DomainId { get; set; }
    }
}
