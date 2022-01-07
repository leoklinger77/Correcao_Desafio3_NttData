using NttDataSupplier.Domain.Models;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{

    public interface ISupplierService : IServiceBase<Supplier>
    {
        Task Insert(Supplier supplier);
    }


}
