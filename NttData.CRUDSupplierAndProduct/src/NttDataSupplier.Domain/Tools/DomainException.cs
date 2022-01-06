using System;

namespace NttDataSupplier.Domain.Tools
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
