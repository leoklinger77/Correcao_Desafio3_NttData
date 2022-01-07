using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Infra.Data;

namespace NttDataSupplier.Infra.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(NttDataContext context) : base(context)
        {
        }
    }


}
