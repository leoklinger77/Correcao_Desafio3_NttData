using NttDataSupplier.Domain.Interfaces.Repositorys;
using NttDataSupplier.Domain.Models;
using NttDataSupplier.Infra.Data;

namespace NttDataSupplier.Infra.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(NttDataContext context) : base(context)
        {
        }
    }


}
