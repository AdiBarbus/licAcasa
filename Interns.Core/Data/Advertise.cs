using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Interns.Core.Data
{
    public class Advertise : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? CreateDate { get; set; }

        [Required(ErrorMessage = "Data format: yyyy.mm.dd")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? EndDate { get; set; }

        [Required]
        public string City { get; set; }

        public virtual User User { get; set; }

        public int? UserId { get; set; }

        public virtual Domain Domain { get; set; }

        public int? DomainId { get; set; }

        public virtual SubDomain SubDomain { get; set; }

        public int? SubDomainId { get; set; }
    }
}
