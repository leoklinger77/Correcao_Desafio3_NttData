using NttDataSupplier.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Repositorys
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task RemoveRangeImage(List<Image> images);
        Task InsertImageRanger(IReadOnlyCollection<Image> images);
    }
}
