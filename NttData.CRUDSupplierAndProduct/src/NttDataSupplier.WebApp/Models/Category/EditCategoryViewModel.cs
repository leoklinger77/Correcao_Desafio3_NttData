using System;
using System.ComponentModel.DataAnnotations;

namespace NttDataSupplier.WebApp.Models.Category
{
    public class EditCategoryViewModel
    {        
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "O campo nome deve conter entre 2 e 100 caracteres")]
        public string Name { get; set; }
    }
}
