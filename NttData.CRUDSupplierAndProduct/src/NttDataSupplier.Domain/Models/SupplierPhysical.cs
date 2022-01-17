using NttDataSupplier.Domain.Tools;
using System;

namespace NttDataSupplier.Domain.Models
{
    public class SupplierPhysical : Supplier
    {
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate { get; private set; }

        protected SupplierPhysical() { }

        public SupplierPhysical(string fullName, string cpf, bool active, string fantasyName, string zipCode, string street, string number, string neighborhood, string city, string state,
                                string complement, string reference, string emailAddress, string ddd, string celCelular)
                                    : base(active, fantasyName, zipCode, street, number, neighborhood, city, state,
                                                complement, reference, emailAddress, ddd, celCelular)
        {
            SetFullName(fullName);
            SetCpf(cpf);
        }
        public override void SetFantasyName(string value)
        {
            base.SetFantasyName(value);
        }
        public void SetFullName(string value)
        {
            DomainValidation.ValidateIsNullOrEmpty(value, "O nome é obrigatorio.");
            FullName = value;
        }
        private void SetCpf(string value)
        {            
            DomainValidation.ValidateIsNullOrEmpty(value, "O cpf é obrigatorio.");
            Cpf = value;
        }
        public void SetBirthDate(DateTime value)
        {
            DomainValidation.ValidateIfTrue(value.Date == DateTime.Now.Date, "A data de nascimento não pode ser igual a hoje");
            BirthDate = value;
        }
    }
}
