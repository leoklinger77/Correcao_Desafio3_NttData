using System;

namespace NttDataSupplier.WebApp.Models.Supplier
{
    public class SupplierViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string FantasyName { get; set; }

        public string CompanyName { get; set; }
        public string Cnpj { get; set; }       


        public string FullName { get; set; }
        public string Cpf { get; set; }
        public DateTime InsertDate { get; set; }

        public string GetFullNameOrCompanyName()
        {
            return string.IsNullOrEmpty(CompanyName) ? FullName : CompanyName;
        }

        public string GetCnpjOrCpf()
        {
            return string.IsNullOrEmpty(Cnpj) ? Cpf : Cnpj;
        }
    }
}
