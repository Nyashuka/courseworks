using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class DishCount : IEquatable<DishCount>
    {
        public Dish Dish { get; private set; }
        public int Count { get; private set; }

        public DishCount(Dish dish, int count)
        {
            Dish = dish;
            Count = count;
        }

        public void AddCountDishes(int count)
        {
            Count += count;
        }

        public void DecreaseDishes(int count)
        {
            if(count <= Count)
                Count -= count;
        }

        public bool Equals(DishCount? other)
        {
            if (other == null)
                return false;

            return Dish.Id.Equals(other.Dish.Id);
        }

        public override int GetHashCode()
        {
            return Dish.Id.GetHashCode();
        }
    }
}
