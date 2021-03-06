using System;

namespace NttDataSupplier.WebApp.Models.Category
{
    public class DeleteCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
