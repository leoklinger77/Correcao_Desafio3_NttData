using System;

namespace NttDataSupplier.Domain.Models
{
    public abstract class Supplier : Entity
    {
        public bool Active { get; private set; }
        public string FantasyName { get; private set; }

        protected Supplier() { }

        protected Supplier(bool active, string fantasyName)
        {
            Active = active;
            FantasyName = fantasyName;
        }
    }    
}
