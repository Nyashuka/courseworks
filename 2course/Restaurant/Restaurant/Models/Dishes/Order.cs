using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Order : IEquatable<Order>
    {
        public DateTimeContainer Date { get; protected set; }
        public HashSet<DishCount> Dishes { get; protected set; }

        public Order(DishCount dishCount)
        {
            Date = new DateTimeContainer();
            Dishes = new HashSet<DishCount>();
            AddDish(dishCount);
        }

        public Order(DateTimeContainer date)
        {
            Date = date;
            Dishes = new HashSet<DishCount>();
        }

        public Order(DateTimeContainer date, DishCount dish)
        {
            Date = date;
            Dishes = new HashSet<DishCount>();
            Dishes.Add(dish);
        }

        public void AddDish(DishCount dish)
        {
            if (!Dishes.Contains(dish))
            {
                Dishes.Add(dish);
            }
            else
            {
                DishCount? dishCount;

                if(Dishes.TryGetValue(dish, out dishCount))
                {
                    dishCount.AddCountDishes(dish.Count);
                }
            }
        }

        public void ChangeCountDish(DishCount dish)
        {
            if(Dishes.Contains(dish))
            {
                Dishes.Remove(dish);
                Dishes.Add(dish);
            }
        }

        public void RemoveDish(DishCount dish)
        {
            DishCount? dishCount;
            if(Dishes.TryGetValue(dish, out dishCount))
            {
                if (dish.Count >= dishCount.Count)
                    Dishes.Remove(dish);
                else
                    dishCount.DecreaseDishes(1);
            }
        }

        public bool Equals(Order? other)
        {
            if (other == null)
                return false;

            return Date.Equals(other.Date);
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode();
        }
    }
}
