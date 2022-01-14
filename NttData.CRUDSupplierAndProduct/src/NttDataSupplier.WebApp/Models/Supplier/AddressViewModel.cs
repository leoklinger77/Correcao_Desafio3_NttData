using System;
using System.ComponentModel.DataAnnotations;

namespace NttDataSupplier.WebApp.Models.Supplier
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "O cep é obrigatorio")]
        [Display(Name = "Cep")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O campo cep deve conter 8 caracteres.")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatorio")]
        [Display(Name = "Logradouro")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo logradouro deve conter entre 5 e 100 caracteres.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O Número é obrigatorio")]
        [Display(Name = "Número")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O campo número deve conter entre 1 e 10 caracteres.")]
        public string Number { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O campo complemento deve conter no maximo 100 caracteres.")]
        public string Complement { get; set; }

        [Display(Name = "Referência")]
        [StringLength(100, MinimumLength = 0, ErrorMessage = "O campo referência deve conter no maximo 100 caracteres.")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatorio")]
        [Display(Name = "Bairro")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo bairro deve conter entre 2 e 100 caracteres.")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "O Cidade é obrigatorio")]
        [Display(Name = "Cidade")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo cidade deve conter entre 2 e 100 caracteres.")]
        public string City { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatorio")]
        [Display(Name = "Estado")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo estado deve conter 2 caracteres.")]
        public string State { get; set; }

    }
}
