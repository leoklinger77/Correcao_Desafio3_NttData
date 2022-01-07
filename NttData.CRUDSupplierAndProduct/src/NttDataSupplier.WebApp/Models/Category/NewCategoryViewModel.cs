using System;
using System.ComponentModel.DataAnnotations;

namespace NttDataSupplier.WebApp.Models.Category
{
    public class NewCategoryViewModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 100 caracteres")]
        public string Name { get; set; }
    }

    public class EditCategoryViewModel
    {        
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 100 caracteres")]
        public string Name { get; set; }
    }

    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
