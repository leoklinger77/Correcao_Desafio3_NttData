using NttDataSupplier.Domain.Models.enums;
using NttDataSupplier.Domain.Tools;
using System.Collections.Generic;
using System.Linq;

namespace NttDataSupplier.Domain.Models
{
    public abstract class Supplier : Entity
    {
        public bool Active { get; private set; }
        public string FantasyName { get; protected set; }

        public Address Address { get; private set; }
        public Email Email { get; private set; }


        private List<Phone> _phones = new List<Phone>();
        public IReadOnlyCollection<Phone> Phones => _phones;

        private List<Product> _products = new List<Product>();
        public IReadOnlyCollection<Product> Products => _products;

        protected Supplier() { }
        protected Supplier(bool active, string fantasyName, string zipCode, string street, string number, string neighborhood, string city, string state,
                        string complement, string reference, string emailAddress, string ddd, string celCelular)
        {
            Active = active;
            FantasyName = fantasyName;
            AddAddress(new Address(Id, zipCode, street, number, neighborhood, city, state, complement, reference));
            AddEmail(new Email(Id, emailAddress));
            AddPhone(new Phone(Id, ddd, celCelular, PhoneType.Celular));
        }

        public virtual void SetFantasyName(string value)
        {
            DomainValidation.ValidateIsNullOrEmpty(value, "O nome fantasia é obrigatorio.");
            FantasyName = value;
        }

        public virtual void AddPhone(Phone phone)
        {
            DomainValidation.ValidateIfTrue(_phones.Count >= 3, "A quantidade máximo de telefones permitidos é 3");

            _phones.Add(phone);
        }
        public virtual void UpdatePhone(string ddd, string phone, PhoneType phoneType)
        {
            DomainValidation.ValidateIfTrue(PhoneExist(phoneType), $"O tipo {phoneType} informado não existe para ser atualizado");

            var phoneExist = _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault();
            phoneExist.SetPhone(ddd, phone, phoneType);

        }
        public virtual void RemovePhone(PhoneType phoneType)
        {
            DomainValidation.ValidateIfTrue(PhoneExist(phoneType), $"O tipo {phoneType} informado não existe para ser removido");

            var phoneExist = _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault();
            _phones.Remove(phoneExist);

        }
        public bool PhoneExist(PhoneType phoneType)
        {
            return _phones.Where(x => x.PhoneType == phoneType).FirstOrDefault() == null;
        }

        public virtual void UpdateAddress(string zipCode, string street, string number, string neighborhood, string city, string state,
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

        public virtual void UpdateEmail(string email)
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
