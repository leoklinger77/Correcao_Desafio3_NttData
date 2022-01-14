using NttDataSupplier.Domain.Tools;
using System;

namespace NttDataSupplier.Domain.Models
{
    public class SupplierJuriDical : Supplier
    {
        public string CompanyName { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime OpenDate { get; private set; }

        protected SupplierJuriDical() { }
        public SupplierJuriDical(string companyName, string cnpj, bool active, string fantasyName, string zipCode, string street, string number, string neighborhood, string city, string state,
                                string complement, string reference, string emailAddress, string ddd, string celCelular)
                                    : base(active, fantasyName, zipCode, street, number, neighborhood, city, state,
                                                complement, reference, emailAddress, ddd, celCelular)
        {
            SetCompanyName(companyName);
            SetCnpj(cnpj);
        }

        public void SetCompanyName(string value)
        {
            DomainValidation.ValidateIsNullOrEmpty(value, "A Razão Social é obrigatorio.");
            CompanyName = value;
        }
        public void SetCnpj(string value)
        {
            DomainValidation.ValidateIsNullOrEmpty(value, "O cnpj é obrigatorio.");
            Cnpj = value;
        }
        public void SetOpenDate(DateTime value)
        {
            DomainValidation.ValidateIfTrue(value.Date == DateTime.Now.Date, "A data de abertura não pode ser igual a hoje");
            OpenDate = value;
        }
    }
}
