using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interns.DataAccessLayer.Entities
{
    public class SubDomain : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Advertise> Advertises { get; set; }
        public ICollection<Qa> Qas { get; set; }
        public int DomainId { get; set; }
    }
}
