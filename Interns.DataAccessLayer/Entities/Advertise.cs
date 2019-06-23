using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interns.DataAccessLayer.Entities
{
    public class Advertise : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Details { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? CreateDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? EndDate { get; set; }
        [Required]
        public string City { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Domain Domain { get; set; }
        public int DomainId { get; set; }
        public SubDomain SubDomain { get; set; }
        public int SubDomainId { get; set; }
        public ICollection<Qa> Qas { get; set; }
    }
}
