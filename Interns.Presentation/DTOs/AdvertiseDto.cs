using System;
using System.Collections.Generic;

namespace Interns.Presentation.DTOs
{
    public class AdvertiseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Details { get; set; }
        
        public DateTime? CreateDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        public string City { get; set; }

        //public virtual UserDto User { get; set; }

        public int? UserId { get; set; }

        //public virtual DomainDto Domain { get; set; }

        public int? DomainId { get; set; }

        //public virtual SubDomainDto SubDomain { get; set; }

        public int? SubDomainId { get; set; }

        //public ICollection<QaDto> Qas { get; set; }
    }
}