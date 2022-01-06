using System;

namespace NttDataSupplier.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime InsertDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }                

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
