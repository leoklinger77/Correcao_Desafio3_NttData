using NttDataSupplier.Domain.Models;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{
    public interface IProductService : IServiceBase<Product>
    {
        Task Insert(Product product);
    }


}
