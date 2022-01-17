using NttDataSupplier.Domain.Models.enums;
using NttDataSupplier.WebApp.Extensions.DataAnnotation.Supplier;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [TodayCanNotAttribute]
        public DateTime OpenDate { get; set; }

        [FullNameAttribute]
        public string FullName { get; set; }

        [CpfAttribute]
        public string Cpf { get; set; }

        [TodayCanNotAttribute]
        public DateTime BirthDate { get; set; }

        public SupplierType SupplierType { get; set; }

        public AddressViewModel Address { get; set; }
        public EmailViewModel Email { get; set; }
        public ICollection<PhoneViewModel> Phones { get; set; } = new List<PhoneViewModel>();

        [Required(ErrorMessage = "Telefone celular é obrigatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "O celular esta invalido")]
        public string TelCelular { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "O telefone fixo esta invalido")]
        public string TelHome { get; set; }

        [StringLength(16, MinimumLength = 15, ErrorMessage = "O telefone comercial esta invalido")]
        public string TelComercial { get; set; }
        
        public void SetPhones()
        {
            SetCelular();
            SetHome();
            SetComercial();
        }

        private void SetCelular()
        {
            TelCelular = Phones.Where(x => x.PhoneType == PhoneType.Celular).FirstOrDefault() == null ? string.Empty : Phones.Where(x => x.PhoneType == PhoneType.Celular).First().ToString();
        }

        private void SetHome()
        {
            TelHome = Phones.Where(x => x.PhoneType == PhoneType.Fixo).FirstOrDefault() == null ? string.Empty : Phones.Where(x => x.PhoneType == PhoneType.Fixo).First().ToString();
        }

        private void SetComercial()
        {
            TelComercial = Phones.Where(x => x.PhoneType == PhoneType.Comercial).FirstOrDefault() == null ? string.Empty : Phones.Where(x => x.PhoneType == PhoneType.Comercial).First().ToString();
        }
    }

    public enum SupplierType
    {
        Juridical = 1,
        Physical
    }
}
