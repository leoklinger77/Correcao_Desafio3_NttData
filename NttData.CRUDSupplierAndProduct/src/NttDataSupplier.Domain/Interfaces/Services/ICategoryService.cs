using NttDataSupplier.Domain.Models;
using System;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces.Services
{
    public interface ICategoryService : IServiceBase<Category>
    {
        Task Insert(Category category);
        Task Update(Category category);
        Task Delete(Guid id);
    }
}
