using NttDataSupplier.Domain.Interfaces;
using NttDataSupplier.Domain.Interfaces.Services;
using NttDataSupplier.Domain.Models;

namespace NttDataSupplier.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        public ProductService(INotificationService notificationService) : base(notificationService)
        {
        }
    }
}
