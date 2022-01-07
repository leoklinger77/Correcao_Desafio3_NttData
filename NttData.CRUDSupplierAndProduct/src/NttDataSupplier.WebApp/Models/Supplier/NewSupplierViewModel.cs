using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NttDataSupplier.WebApp.Models.Supplier
{
    public class NewSupplierViewModel
    {
        public bool Active { get; set; }

        [Required(ErrorMessage = "Nome fantasia é obrigatorio")]
        public string FantasyName { get; set; }

        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public DateTime OpenDate { get; set; }


        public string FullName { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }


        public AddressViewModel Address { get; set; }
        public EmailViewModel Email { get; set; }
        public ICollection<PhoneViewModel> Phones { get; set; } = new List<PhoneViewModel>();

        [Required(ErrorMessage = "Telefone celular é obrigatorio")]
        public string TelCelular { get; set; }
        public string TelHome { get; set; }
        public string TelComercial { get; set; }


    }
}
