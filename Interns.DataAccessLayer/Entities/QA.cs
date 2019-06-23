using System.ComponentModel.DataAnnotations;

namespace Interns.DataAccessLayer.Entities
{
    public class Qa : BaseEntity
    {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }

        public int SubDomainId { get; set; }
        public int AdvertiseId { get; set; }
    }
}
