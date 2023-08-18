using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public abstract class DishBase : IEquatable<DishBase>
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        public DishBase(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void ChangeName(string newName)
        {
            if(newName != "")
                Name = newName;
        }

        public bool Equals(DishBase? other)
        {
            if (other == null)
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
