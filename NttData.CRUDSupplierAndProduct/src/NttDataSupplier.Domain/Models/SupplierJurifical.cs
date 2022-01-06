using System;

namespace NttDataSupplier.Domain.Models
{
    public class SupplierJurifical : Supplier
    {
        public string CompanyName { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime OpenDate { get; private set; }

        protected SupplierJurifical() { }

        public SupplierJurifical(string companyName, string cnpj)
        {
            CompanyName = companyName;
            Cnpj = cnpj;
        }
    }
}
