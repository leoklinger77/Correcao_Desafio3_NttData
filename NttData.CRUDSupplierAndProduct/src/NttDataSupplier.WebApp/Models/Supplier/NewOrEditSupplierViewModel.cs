using NttDataSupplier.WebApp.Extensions.DataAnnotation.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NttDataSupplier.WebApp.Models.Supplier
{
    public class NewOrEditSupplierViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }

        [Required(ErrorMessage = "Nome fantasia é obrigatorio")]
        public string FantasyName { get; set; }

        [CompanyNameAttribute]
        public string CompanyName { get; set; }

        [CnpjAttribute]
        public string Cnpj { get; set; }
        public DateTime OpenDate { get; set; }

        [FullNameAttribute]
        public string FullName { get; set; }

        [CpfAttribute]
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }

        public SupplierType SupplierType { get; set; }

        public AddressViewModel Address { get; set; }
        public EmailViewModel Email { get; set; }
        public ICollection<PhoneViewModel> Phones { get; set; } = new List<PhoneViewModel>();

        [Required(ErrorMessage = "Telefone celular é obrigatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "O celular esta invalido")]
        public string TelCelular { get; set; }

        [StringLength(15, MinimumLength = 15, ErrorMessage = "O telefone fixo esta invalido")]
        public string TelHome { get; set; }

        [StringLength(16, MinimumLength = 15, ErrorMessage = "O telefone comercial esta invalido")]
        public string TelComercial { get; set; }
    }

    public enum SupplierType
    {
        Juridical = 1,
        Physical
    }
}
