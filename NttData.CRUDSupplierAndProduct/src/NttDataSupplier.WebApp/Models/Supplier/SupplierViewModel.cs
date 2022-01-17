using NttDataSupplier.Domain.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NttDataSupplier.WebApp.Models.Supplier
{
    public class SupplierViewModel
    {
        public const string Juridical = "Juridical";
        public const string Physical = "Fisica";
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string FantasyName { get; set; }

        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public DateTime OpenDate { get; set; }


        public string FullName { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }

        public DateTime InsertDate { get; set; }

        public EmailViewModel Email { get; set; }
        public ICollection<PhoneViewModel> Phones { get; set; } = new List<PhoneViewModel>();

        public AddressViewModel Address { get; set; }

        public string GetFullNameOrCompanyName()
        {
            return string.IsNullOrEmpty(CompanyName) ? FullName : CompanyName;
        }

        public string GetCnpjOrCpf()
        {
            return string.IsNullOrEmpty(Cnpj) ? Cpf : Cnpj;
        }

        public void SetPhones()
        {
            SetCelular();
            SetHome();
            SetComercial();
        }

        public string PersonType { get; set; }

        public string TelCelular { get; set; }        
        public string TelHome { get; set; }        
        public string TelComercial { get; set; }

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

        public void SetTypePerson()
        {
            PersonType = string.IsNullOrEmpty(Cpf) ? Juridical : Physical;
        }
    }
}
