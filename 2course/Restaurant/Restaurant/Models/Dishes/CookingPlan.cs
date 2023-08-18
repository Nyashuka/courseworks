using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class CookingPlan
    {
        public HashSet<Order> Orders { get; private set; }

        public CookingPlan()
        {
            Orders = new HashSet<Order>();
        }

        public CookingPlan(HashSet<Order> orders)
        {
            Orders = orders;
        }

        public void AddOrder(Order newOrder)
        {
            if (!Orders.Contains(newOrder))
            {
                Orders.Add(newOrder);
            }
        }

        public void RemoveOrder(Order order)
        {
            if (Orders.Contains(order))
            {
                Orders.Remove(order);
            }
        }

        public void AddDishInOrder(DateTimeContainer dateTimeContainer, DishCount dish)
        {
            Order newOrder = new Order(dateTimeContainer, dish);

            if (Orders.Contains(newOrder))
            {
                Order? order;
                if(Orders.TryGetValue(newOrder, out order))
                {
                    order.AddDish(dish);
                }
            }
            else
            {
                Orders.Add(newOrder);
            }
        }

        public void RemoveDishFromOrder(DateTimeContainer dateTimeContainer, DishCount dish)
        {
            Order? order;

            if (Orders.TryGetValue(new Order(dateTimeContainer, dish), out order))
            {
                order.RemoveDish(dish);
            }    
        }

      

    }
}
