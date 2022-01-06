using System;

namespace NttDataSupplier.Domain.Models
{
    public class SupplierJurifical : Supplier
    {
        public string CompanyName { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime OpenDate { get; private set; }

        protected SupplierJurifical() { }
        public SupplierJurifical(string companyName, string cnpj, bool active, string fantasyName, Address address, Email email) 
            : base(active, fantasyName, address, email)
        {            
            SetCompanyName(companyName);
            SetCnpj(cnpj);            
        }

        public void SetCompanyName(string value)
        {
            CompanyName = value;
        }
        public void SetCnpj(string value)
        {
            Cnpj = value;
        }
        public void SetOpenDate(DateTime value)
        {
            OpenDate = value;
        }
    }
}
