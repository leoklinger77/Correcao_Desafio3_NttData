using NttDataSupplier.Domain.Models;
using NttDataSupplier.Domain.Notifier;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NttDataSupplier.Domain.Interfaces
{
    public interface INotificationService
    {
        void AddErro(string erro);
        bool HasError();
        IEnumerable<Notification> AllError();
        
    }
}
