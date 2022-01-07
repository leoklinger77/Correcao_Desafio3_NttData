using NttDataSupplier.Domain.Models;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{
    public interface ICategoryService : IServiceBase<Category>
    {
        Task Insert(Category category);
    }
}
