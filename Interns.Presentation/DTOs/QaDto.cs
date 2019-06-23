namespace Interns.Presentation.DTOs
{
    public class QaDto
    {
        public int Id { get; set; }

        public string Question { get; set; }
        
        public string Answer { get; set; }

        public int? SubDomainId { get; set; }

        public int? AdvertiseId { get; set; }
    }
}