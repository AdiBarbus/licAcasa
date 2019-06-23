using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interns.DataAccessLayer.Entities
{
    public class Domain : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<SubDomain> SubDomains { get; set; }
        public ICollection<Advertise> Advertises { get; set; }
    }
}
