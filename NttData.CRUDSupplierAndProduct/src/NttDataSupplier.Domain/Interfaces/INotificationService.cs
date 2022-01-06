using NttDataSupplier.Domain.Notifier;
using System.Collections.Generic;

namespace NttDataSupplier.Domain.Interfaces
{
    public interface INotificationService
    {
        void AddErro(string erro);
        bool HasError();
        IEnumerable<Notification> AllError();

    }
}
