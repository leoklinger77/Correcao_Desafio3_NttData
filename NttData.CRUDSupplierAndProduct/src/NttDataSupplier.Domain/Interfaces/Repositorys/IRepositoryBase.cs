using NttDataSupplier.Domain.Models;
using System;

namespace NttDataSupplier.Domain.Interfaces.Repositorys
{
    public interface IRepositoryBase<T> : IDisposable where T : Entity
    {
    }
}
