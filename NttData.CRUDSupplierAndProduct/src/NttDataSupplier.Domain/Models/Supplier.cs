using NttDataSupplier.Domain.Models.enums;
using NttDataSupplier.Domain.Tools;
using System.Collections.Generic;
using System.Linq;

namespace NttDataSupplier.Domain.Models
{
    public abstract class Supplier : Entity
    {
        public bool Active { get; private set; }
        public string FantasyName { get; private set; }

        public Address Address { get; private set; }
        public Email Email { get; private set; }


        private List<Phone> _phones = new List<Phone>();
        public IReadOnlyCollection<Phone> Phones => _phones;
        
        private List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products;

        protected Supplier() { }
        protected Supplier(bool active, string fantasyName, Address address, Email email, Phone phone)
        {
            Active = active;
            FantasyName = fantasyName;
            AddAddress(address);
            AddEmail(email);            
            AddPhone(phone);
        }

        public void AddPhone(Phone phone)
        {
            DomainValidation.ValidateIfTrue(_phones.Count >= 3, "A quantidade máximo de telefones permitidos é 3");

            _phones.Add(phone);
        }
        public void UpdatePhone(string ddd, string phone, PhoneType phoneType)
        {
            DomainValidation.ValidateIfTrue(PhoneExist(phoneType), $"O tipo {phoneType} informado não existe para ser atualizado");

            var phoneExist = _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault();
            phoneExist.SetPhone(ddd, phone, phoneType);

        }
        public void RemovePhone(PhoneType phoneType)
        {
            DomainValidation.ValidateIfTrue(PhoneExist(phoneType), $"O tipo {phoneType} informado não existe para ser removido");
            
            var phoneExist = _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault();
            _phones.Remove(phoneExist);

        }
        private bool PhoneExist(PhoneType phoneType)
        {
            return _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault() == null;
        }

        public void UpdateAddress(string zipCode, string street, string number, string neighborhood, string city, string state,
                        string complement = null, string reference = null)
        {   
            Address.SetAddress(zipCode, street, number, neighborhood, city, state,
                         complement, reference);
        }
        private void AddAddress(Address address)
        {
            DomainValidation.ValidateIfTrue(address == null, "É obrigatorio informar um endereço");
            Address = address;
        }

        public void UpdateEmail(string email)
        {            
            Email.SetEmail(email);
        }        
        private void AddEmail(Email email)
        {
            DomainValidation.ValidateIfTrue(email == null, "É obrigatorio informar um e-mail");
            Email = email;
        }
    }
}
