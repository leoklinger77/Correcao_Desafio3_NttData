using System;
using System.ComponentModel.DataAnnotations;

namespace NttDataSupplier.WebApp.Models.Supplier
{
    public class EmailViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatorio")]
        [EmailAddress(ErrorMessage = "O e-mail esta invalido")]
        public string EmailAddress { get; set; }

    }
}
