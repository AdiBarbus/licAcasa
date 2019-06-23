using System.Collections.Generic;

namespace Interns.Services.Helpers
{ 
    public class SearchingAndPagingViewModel<T>
    {
        public IEnumerable<T> Collection { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SearchString { get; set; }
        public string SortingOrder { get; set; }
    }
}