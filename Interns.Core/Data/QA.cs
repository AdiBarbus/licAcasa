using System.ComponentModel.DataAnnotations;

namespace Interns.Core.Data
{
    public class Qa : BaseEntity
    {
        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public int? SubDomainId { get; set; }

        public int? DomainId { get; set; }
    }
}
