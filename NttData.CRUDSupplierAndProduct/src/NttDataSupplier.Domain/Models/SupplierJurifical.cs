using NttDataSupplier.Domain.Tools;
using System;

namespace NttDataSupplier.Domain.Models
{
    public class SupplierJurifical : Supplier
    {
        public string CompanyName { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime OpenDate { get; private set; }

        protected SupplierJurifical() { }
        public SupplierJurifical(string companyName, string cnpj, bool active, string fantasyName, Address address, Email email, Phone phone) 
            : base(active, fantasyName, address, email, phone)
        {            
            SetCompanyName(companyName);
            SetCnpj(cnpj);            
        }

        public void SetCompanyName(string value)
        {
            Validation.ValidateIsNullOrEmpty(value, "A Razão Social é obrigatorio.");
            CompanyName = value;
        }
        public void SetCnpj(string value)
        {
            Validation.ValidateIsNullOrEmpty(value, "O cnpj é obrigatorio.");
            Validation.ValidateIfFalse(value.IsCnpj(), "O Cnpj informado é inválido.");
            Cnpj = value;
        }
        public void SetOpenDate(DateTime value)
        {
            Validation.ValidateIfTrue(value.Date == DateTime.Now.Date, "A data de abertura não pode ser igual a hoje");
            OpenDate = value;
        }
    }
}
