using System.Collections.Generic;

namespace NttDataSupplier.Domain.Models
{
    public class PaginationModel<T> where T : Entity
    {
        public string ReferenceAction { get; set; }
        public IEnumerable<T> List { get; set; } = new List<T>();
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
        public int TotalResult { get; set; }        
    }
}
