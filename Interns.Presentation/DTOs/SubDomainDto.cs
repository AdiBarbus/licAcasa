using System.Collections.Generic;

namespace Interns.Presentation.DTOs
{
    public class SubDomainDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public ICollection<AdvertiseDto> Advertises { get; set; }

        //public ICollection<QaDto> Qas { get; set; }

        public int? DomainId { get; set; }
    }
}