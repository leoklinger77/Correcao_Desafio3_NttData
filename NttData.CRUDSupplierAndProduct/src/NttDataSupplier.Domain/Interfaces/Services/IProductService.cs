using NttDataSupplier.Domain.Models;
using System;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        Task Insert(Product product);
        Task Delete(Guid id);
        Task Update(Product product);
    }


}
