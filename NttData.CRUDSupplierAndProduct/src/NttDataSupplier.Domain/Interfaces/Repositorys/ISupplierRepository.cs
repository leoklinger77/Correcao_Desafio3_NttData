using NttDataSupplier.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Repositorys
{
    public interface ISupplierRepository : IRepositoryBase<Supplier>
    {
        Task InsertJu(SupplierJuriDical juriDical);
        Task InsertPh(SupplierPhysical physical);

        Task InsertAddress(Address address);
        Task InsertEmail(Email email);
        Task InsertPhoneRanger(IEnumerable<Phone> phones);

        Task<IEnumerable<Supplier>> FindAllAndProduct();
    }
}
