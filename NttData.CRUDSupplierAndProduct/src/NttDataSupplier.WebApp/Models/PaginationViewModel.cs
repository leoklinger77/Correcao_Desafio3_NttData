using System;
using System.Collections.Generic;

namespace NttDataSupplier.WebApp.Models
{    
    public class PaginationViewModel<T> where T : class
    {
        public string ReferenceAction { get; set; }
        public IEnumerable<T> List { get; set; } = new List<T>();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public int TotalResult { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalResult / PageSize);
    }
}
