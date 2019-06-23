using System.Collections.Generic;
using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.Models.SelectFK
{
    public class SelectDomainViewModel
    {
        public IQueryable<Domain> Domains { get; set; }
        public int SelectedDomainId { set; get; }
    }
}
