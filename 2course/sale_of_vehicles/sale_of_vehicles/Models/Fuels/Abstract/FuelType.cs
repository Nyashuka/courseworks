using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sale_of_vehicles
{
    public abstract class FuelType : IEquatable<FuelType>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;

        protected FuelType(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public bool Equals(FuelType? other)
        {
            if (other == null)
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
