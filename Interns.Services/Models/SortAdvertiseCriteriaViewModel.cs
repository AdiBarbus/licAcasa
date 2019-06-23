using System;
using System.Collections.Generic;
using System.Linq;
using Interns.Core.Data;

namespace Interns.Services.Models
{
    public class SortAdvertiseCriteriaViewModel
    {
        public IQueryable<Advertise> Advertises { get; set; }
        public Int16 SelectedCriteria { get; set; }
    }
}
