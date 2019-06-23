using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.Models.SelectFK
{
    public class SelectQuestionsFK
    {
        public IQueryable<Test> Tests { get; set; }
        public int SelectedTestId { set; get; }

        public IQueryable<Domain> Domains { get; set; }
        public int SelectedDomainId { set; get; }

        public IQueryable<SubDomain> SubDomains { get; set; }
        public int SelectedSubDomainId { set; get; }
    }
}
